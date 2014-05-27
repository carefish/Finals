﻿using UnityEditor;
[CustomEditor(typeof(DropBorders))]
public class DropBordersHelper : Editor {
    public override void OnInspectorGUI()
    {
        DropBorders t = (DropBorders)target;
        t.easeDuration = EditorGUILayout.Slider("Ease Duration: ", t.easeDuration, 0.01f, 50.0f);
        t.liftDuration = EditorGUILayout.Slider("Lift Duration: ", t.liftDuration, 0.01f, 50.0f);
    }
}