using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FP_InputVector3
{
	public FP_InputFloat _x;
	public FP_InputFloat _y;
	public FP_InputFloat _z;
	public bool _normalize;

	public Vector3 DefineVector3()
	{
		Vector3 rawVector = new Vector3(_x.DefineFloat(), _y.DefineFloat(), _z.DefineFloat());
		if(_normalize)
		{
			rawVector.Normalize();
		}

		return rawVector;
	}
}
