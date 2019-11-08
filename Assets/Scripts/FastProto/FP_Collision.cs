using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class FP_Collision : FP_Main
{
	Collider _collider;

	public UnityEvent OnEnter;
	public UnityEvent OnStay;
	public UnityEvent OnExit;

	public bool _destroyOnHit;
	public bool _destroyCollidedObjectOnHit;

	public LayerMask _layer;

	private void Awake()
	{
		_collider = GetComponent<Collider>();
		if(_collider.isTrigger != false)
		{
			Destroy(this);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(_enable && _layer ==(_layer|(1<<collision.collider.gameObject.layer)))
		{
			OnEnter.Invoke();
			if(_destroyCollidedObjectOnHit) Destroy(collision.collider.gameObject);

			if(_destroyOnHit) Destroy(gameObject);
		}
	}

	private void OnCollisionStay(Collision collision)
	{
		if(_enable && _layer == (_layer | (1 << collision.collider.gameObject.layer)))
		{
			OnStay.Invoke();
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if(_enable && _layer == (_layer | (1 << collision.collider.gameObject.layer)))
		{
			OnExit.Invoke();
		}
	}
}
