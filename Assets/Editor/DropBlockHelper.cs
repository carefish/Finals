using UnityEditor;
[CustomEditor(typeof(DropBlock))]
public class DropBlockHelper : Editor {
    public override void OnInspectorGUI()
    {
        DropBlock t = (DropBlock)target;
        t.easeDuration = EditorGUILayout.Slider("Ease Duration: ", t.easeDuration, 0.01f, 50.0f);
    }
}
