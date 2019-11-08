using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FloatType {Value,Input}

[System.Serializable]
public class FP_InputFloat
{
	public FloatType _floatType = FloatType.Value;
	public float _value;
	public Vector2 _minMaxInput = new Vector2(-1, 1);
	public string _input;

	public float DefineFloat()
	{
		if(_floatType==FloatType.Value)
		{
			return _value;
		}
		else
		{
			if(_input == ""&& !Application.isEditor)
			{
				_floatType = FloatType.Value;
				Debug.LogWarning("A floatType is set to Input but the axis name is undefined");
				return _value;
			}
			float rawAxis = Input.GetAxis(_input);
			return Mathf.Lerp(_minMaxInput.x, _minMaxInput.y, Mathf.InverseLerp(-1, 1, rawAxis));
		}
	}
}
