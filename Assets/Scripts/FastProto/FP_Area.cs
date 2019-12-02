using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class FP_Area : FP_Main
{
	Collider _collider;

	public UnityEvent OnEnter;
	public UnityEvent OnStay;
	public UnityEvent OnExit;

	public bool _destroyOnEnter;
	public bool _destroyEnteringObjectOnEnter;

	public LayerMask _layer;


	private void Awake()
	{
		_collider = GetComponent<Collider>();
		if(_collider.isTrigger!=true)
		{
			Destroy(this);
		}
	}


	private void OnTriggerEnter(Collider other)
	{

		if(_enable && _layer == (_layer | (1 << other.gameObject.layer)))
		{
			OnEnter.Invoke();
			if(_destroyEnteringObjectOnEnter) Destroy(other.gameObject);

			if(_destroyOnEnter) Destroy(gameObject);
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if(_enable && _layer == (_layer | (1 << other.gameObject.layer)))
		{
			OnStay.Invoke();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if(_enable && _layer == (_layer | (1 << other.gameObject.layer)))
		{
			OnExit.Invoke();
		}
	}
}
