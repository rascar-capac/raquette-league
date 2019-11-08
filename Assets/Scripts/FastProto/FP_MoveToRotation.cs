using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP_MoveToRotation : FP_Main
{
	[Header("Forward Vector")]
	public bool _forwardTarget;
	public FP_Space _forwardSpace;
	public Transform _spaceForwardRef;
	public FP_InputVector3 _forwardVector;

	[Header("Upward Vector")]
	[Space(10)]
	public bool _upwardTarget;
	public FP_Space _upwardSpace;
	public Transform _spaceUpwardRef;
	public FP_InputVector3 _upwardVector;


    void Update()
    {
		// Define zVector
		Vector3 zVector = DefineDirectionVector(_forwardVector.DefineVector3(),_forwardSpace,_spaceForwardRef,_forwardTarget);

		// Define yVector
		Vector3 yVector = DefineDirectionVector(_upwardVector.DefineVector3(), _upwardSpace,_spaceUpwardRef,_upwardTarget);

		// Apply rotation
		transform.rotation = Quaternion.LookRotation(zVector, yVector);
	}
}
