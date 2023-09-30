using System;
using UnityEditor;
using UnityEngine;

public class DemoWindow : EditorWindow
{
	private static SerializedProperty firstBoolProp;
	private static SerializedProperty secondBoolProp;
	private static SerializedProperty firstFloatProp;
	private static SerializedProperty firstIntProp;

	public static bool FirstBool => firstBoolProp.boolValue;
	public static bool SecondBool => secondBoolProp.boolValue;
	public static float FirstFloat => firstFloatProp.floatValue;
	public static int FirstInt => firstIntProp.intValue;

	private static EditorSettings settings;
	private static SerializedObject serializedSettings;

	[MenuItem("Custom/My Custom Window")]
	public static void ShowWindow() => GetWindow<DemoWindow>("Custom Window");

	private void OnEnable()
	{
		settings = CreateInstance<EditorSettings>();
		serializedSettings = new SerializedObject(settings);
		firstBoolProp = serializedSettings.FindProperty("firstBool");
		secondBoolProp = serializedSettings.FindProperty("secondBool");
		firstFloatProp = serializedSettings.FindProperty("firstFloat");
		firstIntProp = serializedSettings.FindProperty("firstInt");
	}

	private void OnGUI()
	{
		serializedSettings.Update();

		EditorGUILayout.PropertyField(firstBoolProp, new GUIContent("First Bool:"));
		EditorGUILayout.PropertyField(secondBoolProp, new GUIContent("Second Bool:"));
		EditorGUILayout.PropertyField(firstFloatProp, new GUIContent("First Float:"));
		EditorGUILayout.PropertyField(firstIntProp, new GUIContent("First Int:"));

		serializedSettings.ApplyModifiedProperties();
	}
}

public class EditorSettings : ScriptableObject
{
	public bool firstBool = false;
	public bool secondBool = false;
	public float firstFloat = 1f;
	public int firstInt = 0;
}