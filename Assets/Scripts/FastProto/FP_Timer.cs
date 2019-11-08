using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FP_Timer : FP_Main
{
	float lastTime;
	public float _initialDelay;
	public float _delay;

	public int _repeatNumber = 9999;

	public UnityEvent OnRepeat;

	private void Awake()
	{
		if(_repeatNumber == 0) Destroy(this);

		StartCoroutine(Timing());
	}

	IEnumerator Timing()
	{
		float t = 0;

        while (t<_initialDelay)
        {
            if (_enable)
            {
                t += Time.deltaTime;
                if (t > _initialDelay)
                {
                    OnRepeat.Invoke();
                }
            }
            yield return null;
        }

	    int i = 1;
		lastTime = Time.time;
        t = 0;

        while (i<=_repeatNumber)
		{
			if(_enable)
			{
				t += Time.deltaTime;
				if(Time.time>lastTime+_delay)
				{
					OnRepeat.Invoke();
					lastTime = Time.time;
				}
			}
            else
            {
                lastTime = Time.time;
            }
			yield return null;
		}

		Destroy(this);
	}
}
