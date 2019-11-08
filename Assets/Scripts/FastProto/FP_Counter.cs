using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FP_Counter : FP_Main
{
	public int _counter=0;
	public Vector2Int _minMax = Vector2Int.up;
	public UnityEvent OnDecreaseCounter;
	public UnityEvent OnIncreaseCounter;
	public UnityEvent OnReachMaxCounter;
	public UnityEvent OnReachMinCounter;


	public void ModifyCounter(int value)
	{
        if (_enable)
        {
            _counter = Mathf.Clamp(_counter + value, _minMax.x, _minMax.y);

		    if(value > 0) OnIncreaseCounter.Invoke();
		    else if(value < 0) OnDecreaseCounter.Invoke();

		    if(_counter == _minMax.x) OnReachMinCounter.Invoke();
		    else if(_counter == _minMax.y) OnReachMaxCounter.Invoke();
        }
	}
}
