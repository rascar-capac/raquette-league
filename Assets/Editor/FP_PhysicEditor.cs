using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FP_PhysicEditor : Editor
{
	protected void DisplayInputFloat(FP_InputFloat inputFloat, string name)
	{
		EditorGUILayout.BeginVertical(GUI.skin.box);
		if(inputFloat._floatType == FloatType.Value)
		{
			GUILayout.BeginHorizontal();
			GUILayout.Label(name);
			inputFloat._value = EditorGUILayout.FloatField(inputFloat._value);
			inputFloat._floatType = (FloatType)EditorGUILayout.EnumPopup(inputFloat._floatType);
			GUILayout.EndHorizontal();
		}
		else
		{
			GUILayout.BeginHorizontal();
			GUILayout.Label(name + " Input");
			inputFloat._input = EditorGUILayout.TextField(inputFloat._input, GUILayout.ExpandWidth(true));
			inputFloat._floatType = (FloatType)EditorGUILayout.EnumPopup(inputFloat._floatType);
			GUILayout.EndHorizontal();
			inputFloat._minMaxInput = EditorGUILayout.Vector2Field("Min/Max", inputFloat._minMaxInput);
		}
		EditorGUILayout.EndVertical();
	}
	protected void DisplayInputVector3(FP_InputVector3 inputVector3)
	{
		DisplayInputFloat(inputVector3._x, "X");
		DisplayInputFloat(inputVector3._y, "Y");
		DisplayInputFloat(inputVector3._z, "Z");
	}
	protected void DisplaySpace(ref FP_Space space, SerializedProperty spaceRef)
	{
		GUILayout.BeginHorizontal();
		space = (FP_Space)EditorGUILayout.EnumPopup(space, GUILayout.MaxWidth(60));
		GUILayout.Space(50);
		EditorGUILayout.PropertyField(spaceRef);
		GUILayout.EndHorizontal();
	}
	protected void DisplaySpacePosition(ref FP_Space space,SerializedProperty spaceRef,FP_InputVector3 inputVector3,string name)
	{
		EditorGUILayout.LabelField(name, EditorStyles.boldLabel);
		EditorGUILayout.BeginVertical(GUI.skin.button);
		DisplaySpace(ref space, spaceRef);
		DisplayInputVector3(inputVector3);
		EditorGUILayout.EndVertical();
	}

	protected void DisplaySpacePositionTarget(ref FP_Space space, SerializedProperty spaceRef, FP_InputVector3 inputVector3, string name,  ref bool target)
	{
		EditorGUILayout.LabelField(name, EditorStyles.boldLabel);
		EditorGUILayout.BeginVertical(GUI.skin.button);
		DisplaySpace(ref space, spaceRef);
		target = GUILayout.Toggle(target, "Target", GUILayout.ExpandWidth(false));
		DisplayInputVector3(inputVector3);
		EditorGUILayout.EndVertical();
	}

	protected void DisplayEvents(SerializedProperty[] events,bool enable=true)
	{
		if(enable)
		{
			for(int i = 0; i < events.Length; i++)
			{
				EditorGUILayout.PropertyField(events[i]);
			}
		}
	}
}
