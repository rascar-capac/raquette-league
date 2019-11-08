using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP_MoveToPosition : MonoBehaviour
{
	public Vector3 _position;
	public FP_Space _space;
	public Transform _spaceRef;

    void Update()
    {
		if(_space == FP_Space.World)
		{
			transform.position = _position;
		}
		else if(_space == FP_Space.Local && _spaceRef != null)
		{
			transform.position = _spaceRef.TransformPoint(_position);
		}
    }
}
