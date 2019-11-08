using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum MouseInput {LeftClic,RightClic,MiddleClic }

public class FP_MouseInput : FP_Main
{
	public MouseInput _mouseButton;

	public UnityEvent OnMouseDown;
	public UnityEvent OnMouseHold;
	public UnityEvent OnMouseUp;

	private void Update()
	{
		if(Input.GetMouseButtonDown((int)_mouseButton))
		{
			OnMouseDown.Invoke();
		}

		if(Input.GetMouseButton((int)_mouseButton))
		{
			OnMouseHold.Invoke();
		}

		if(Input.GetMouseButtonUp((int)_mouseButton))
		{
			OnMouseUp.Invoke();
		}
	}
}
