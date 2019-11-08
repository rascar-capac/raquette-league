using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

[CanEditMultipleObjects]
[CustomEditor(typeof(FP_TorqueToRotation))]
public class FP_TorqueToRotationEditor : FP_PhysicEditor
{
	FP_TorqueToRotation _script;

	SerializedProperty[] Events;

	SerializedProperty ForwardSpaceRef;
	SerializedProperty UpwardSpaceRef;

	private void OnEnable()
	{
		_script = (FP_TorqueToRotation)target;

		Events = new SerializedProperty[] { serializedObject.FindProperty("OnEnterAlign"), serializedObject.FindProperty("OnAlign") , serializedObject.FindProperty("OnExitAlign") , serializedObject.FindProperty("OnNotAlign") };

		ForwardSpaceRef = serializedObject.FindProperty("_forwardSpaceRef");
		UpwardSpaceRef = serializedObject.FindProperty("_upwardSpaceRef");
	}

	public override void OnInspectorGUI()
	{
		EditorGUIUtility.labelWidth = 150;

		GUILayout.Space(5);

		_script._enable = GUILayout.Toggle(_script._enable,"Enable", GUILayout.ExpandWidth(false));

		GUILayout.Space(10);

		//Start ForwardSpace
		DisplaySpacePositionTarget(ref _script._forwardSpace, ForwardSpaceRef, _script._forwardVector, "Forward Direction",ref _script._forwardTarget);
		// End ForwardSpace

		GUILayout.Space(10);

		//Start UpwardSpace
		DisplaySpacePositionTarget(ref _script._upwardSpace, UpwardSpaceRef, _script._upwardVector, "Upward Direction", ref _script._upwardTarget);
		// End UpwardSpace

		GUILayout.Space(10);

		DisplayInputFloat(_script._force, "Torque");

		GUILayout.Space(10);

		_script._isUsingEvents = GUILayout.Toggle(_script._isUsingEvents, "Use Events", GUILayout.ExpandWidth(false));
		if(_script._isUsingEvents)
		{
			_script._angle = EditorGUILayout.Slider("Angle",_script._angle,0,180);
			DisplayEvents(Events);
		}

		serializedObject.ApplyModifiedProperties();
	}

	
}
