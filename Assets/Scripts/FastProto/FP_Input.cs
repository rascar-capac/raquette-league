using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public enum InputType {Key,Button }

public class FP_Input : FP_Main
{
	public InputType _inputType;

	public KeyCode[] _keys;

	public UnityEvent OnKeyDown;
	public UnityEvent OnKey;
	public UnityEvent OnKeyUp;

	public string[] _buttons;

	public UnityEvent OnButtonDown;
	public UnityEvent OnButton;
	public UnityEvent OnButtonUp;

	private void Awake()
	{
		if(_inputType == InputType.Key)
		{
			if(_keys.Length>0)
			{
				StartCoroutine(UpdatingKey());
			}
			else
			{
				Destroy(this);
			}
		}
		else
		{
			if(_buttons.Length > 0)
			{
				StartCoroutine(UpdatingButton());
			}
			else
			{
				Destroy(this);
			}
		}
	}

	IEnumerator UpdatingKey()
	{
		while(true)
		{
			for(int i = 0; i < _keys.Length; i++)
			{
				if(Input.GetKeyDown(_keys[i]))
				{
					OnKeyDown.Invoke();
				}
				if(Input.GetKey(_keys[i]))
				{
					OnKey.Invoke();
				}
				if(Input.GetKeyUp(_keys[i]))
				{
					OnKeyUp.Invoke();
				}
			}
			yield return null;
		}
	}

	IEnumerator UpdatingButton()
	{
		while(true)
		{
			for(int i = 0; i < _buttons.Length; i++)
			{
				if(Input.GetButtonDown(_buttons[i]))
				{
					OnButtonDown.Invoke();
				}
				if(Input.GetButton(_buttons[i]))
				{
					OnButton.Invoke();
				}
				if(Input.GetButtonUp(_buttons[i]))
				{
					OnButtonUp.Invoke();
				}
			}

			yield return null;
		}
	}
}
