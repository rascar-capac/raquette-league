using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FP_ForceToPosition))]
public class FP_ForceToPositionEditor : FP_PhysicEditor
{

	FP_ForceToPosition _script;

	SerializedProperty[] Events;

	SerializedProperty SpaceRef;

	private void OnEnable()
	{
		_script = (FP_ForceToPosition)target;

		Events = new SerializedProperty[] { serializedObject.FindProperty("OnEnter"), serializedObject.FindProperty("OnIn"), serializedObject.FindProperty("OnExit"), serializedObject.FindProperty("OnOut") };

		SpaceRef = serializedObject.FindProperty("_spaceRef");

	}

	public override void OnInspectorGUI()
	{
		EditorGUIUtility.labelWidth = 150;

		GUILayout.Space(5);

		_script._enable = GUILayout.Toggle(_script._enable, "Enable", GUILayout.ExpandWidth(false));

		GUILayout.Space(10);

		DisplaySpacePosition(ref _script._space, SpaceRef, _script._position, "Position");

		GUILayout.Space(10);

		DisplayInputFloat(_script._force, "Force");

		GUILayout.Space(10);

		_script._isUsingEvents = GUILayout.Toggle(_script._isUsingEvents, "Use Events", GUILayout.ExpandWidth(false));

		if(_script._isUsingEvents)
		{
			_script._radius = EditorGUILayout.FloatField("Radius", _script._radius);
			DisplayEvents(Events);
		}

		serializedObject.ApplyModifiedProperties();
	}
}
