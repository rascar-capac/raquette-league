using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FP_Spawner : FP_Main
{
	public GameObject _objectToSpawn;
	public float _spawnDelay=1;
    public bool _useRandom = false;
    public Vector2 _minMaxRandom = Vector2.up;
    [Space(10)]

	float _lastSpawnTime;
	public float _destroyDelay=0;
	public bool _autoSpawn = false;
	public bool _useArea = false;
    public Transform _parent;
	Collider _collider;

    public UnityEvent OnSpawn;

	private void Awake()
	{
		_collider = gameObject.GetComponent<Collider>();
		if(_useArea)
		{
			if(_collider !=null && _collider.isTrigger==true)
			{
				if(_collider.GetType() != typeof(SphereCollider) && _collider.GetType() != typeof(BoxCollider))
				{
					_useArea = false;
				}
			}
			else
			{
				_useArea = false;
				Debug.LogWarning("You should use a SphereCollider or a BoxCollider with isTrigger checked if you want to use a spawn area ;) keep going!");
			}
		}

		_lastSpawnTime = Time.time;
        if (_useRandom) RandomizeDelay();

        if (_autoSpawn)
		{
			StartCoroutine(Spawning());
		}
	}
	public Vector3 _localSpawnVelocity;

    void RandomizeDelay()
    {
        _spawnDelay = Random.Range(_minMaxRandom.x, _minMaxRandom.y);
    }

	IEnumerator Spawning()
	{
		while(true)
		{
			if(_enable)
			{
				Spawn();
			}
			yield return null;
		}
	}

	public void Spawn()
	{
		if(_enable&&_objectToSpawn!=null&& Time.time>_lastSpawnTime+_spawnDelay)
		{
			Vector3 spawnPosition;

			if(_useArea)
			{
				if(_collider.GetType() == typeof(SphereCollider))
				{
					SphereCollider sphere = (SphereCollider)_collider;
					spawnPosition = transform.TransformPoint(sphere.center + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * Random.Range(0, sphere.radius));
					Debug.Log(new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1)).normalized);
				}
				else
				{
					BoxCollider box = (BoxCollider)_collider;
					Vector3 extents = box.size * 0.5f;
					spawnPosition = transform.TransformPoint(box.center + new Vector3(Random.Range(-extents.x, extents.x), Random.Range(-extents.y, extents.y), Random.Range(-extents.z, extents.z)));
				}
			}
			else
			{
				spawnPosition = transform.position;
			}

            OnSpawn.Invoke();

            GameObject go = Instantiate(_objectToSpawn, spawnPosition, transform.rotation);
            if (_parent) go.transform.SetParent(_parent);

			if(_destroyDelay>0)
			{
				Destroy(go, _destroyDelay);
			}

			_lastSpawnTime = Time.time;
            if (_useRandom) RandomizeDelay();

			Rigidbody rb = go.GetComponent<Rigidbody>();
			if(rb)
			{
				rb.velocity = transform.TransformDirection(_localSpawnVelocity);
			}
		}
	}
}
