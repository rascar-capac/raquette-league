using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

public class FP_ForceToPosition : FP_Physic
{
	public FP_InputVector3 _position;
	public FP_Space _space;
	public Transform _spaceRef;

	Vector3 _worldPosition;
	Vector3 _forceDirection;

	public UnityEvent OnEnter;
	public UnityEvent OnIn;
	public UnityEvent OnExit;
	public UnityEvent OnOut;

	public float _radius;

	bool _isIn;


	void Update()
    {
		//Define _worldPosition
		DefineWorldPosition();

		//Define _forceDirection using _worldPosition
		_forceDirection = (_worldPosition - transform.position).normalized;
	}


	protected override IEnumerator TestingEvents()
	{
		while(true)
		{
			float distance = Vector3.Distance(transform.position, _worldPosition);

			if(distance < _radius)
			{
				if(_isIn == false)
				{
					OnEnter.Invoke();
					_isIn = true;
				}
				OnIn.Invoke();
			}
			else
			{
				if(_isIn == true)
				{
					OnExit.Invoke();
					_isIn = false;
				}
				OnOut.Invoke();
			}
			yield return null;
		}
	}

	void DefineWorldPosition()
	{
		_worldPosition = DefinePositionVector(_position.DefineVector3(), _space, _spaceRef);
	}

	protected override void ApplyForce()
	{
		_rigidbody.AddForce(_forceDirection * _force.DefineFloat() * Time.fixedDeltaTime);
	}

	private void OnDrawGizmosSelected()
	{
		DefineWorldPosition();

		Handles.color = Color.white;
		if(_space == FP_Space.Local)
		{
			Handles.DrawLine(transform.position, _worldPosition);
		}
		else
		{
			Handles.DrawDottedLine(transform.position, _worldPosition,10);
			Gizmos.DrawIcon(_worldPosition, "Target", true);
		}
	}
}
