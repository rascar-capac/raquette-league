using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class FP_Physic : FP_Main
{
	public bool _isUsingEvents = false;
	protected Rigidbody _rigidbody;
	public FP_InputFloat _force;

	protected void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
		StartCoroutine(ApplyingContinuousForce());
		if(_isUsingEvents) StartCoroutine(TestingEvents());
	}

	protected virtual IEnumerator TestingEvents()
	{
		// Override this in any child class
		yield return null;
	}

	IEnumerator ApplyingContinuousForce()
	{
		while(true)
		{
			while(_enable)
			{
				ApplyForce();
				yield return new WaitForFixedUpdate();
			}
			yield return null;
		}
	}

	protected virtual void ApplyForce()
	{
		// Override this in any child class
	}
}
