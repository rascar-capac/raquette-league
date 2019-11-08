using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(JengaTowerGenerator))]
public class JengaTowerGeneratorEditor : Editor
{
	public JengaTowerGenerator _myScript;
	private void OnEnable()
	{
		_myScript = (JengaTowerGenerator)target;
	}

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		if(GUILayout.Button("Create Tower"))
		{
			_myScript.CreateJengaTower(_myScript._floorCount);
		}

		if(GUILayout.Button("Create City"))
		{
			_myScript.CreateJengaCity();
		}
	}
}
