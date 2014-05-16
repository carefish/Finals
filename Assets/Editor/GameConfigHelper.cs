using UnityEditor;
[CustomEditor(typeof(GameConfig))]
public class GameConfigHelper : Editor {
    UnityEngine.Vector2 helperScroll;
    string helperText = @"This object provides quick and easy access
to perform minor tweaks or adjustments.
For this project you need to provide a 
valid level name.
You can look inside the Resources/Levels/
folder for valid level names.
Keep in mind that every level prefab needs
to have a Game Object named 'SpawnPoint'.";
    public override void OnInspectorGUI()
    {
        UnityEngine.GUI.enabled = false;
        helperText      = EditorGUILayout.TextArea(helperText);
        UnityEngine.GUI.enabled = true;
        GameConfig t    = (GameConfig)target;
        t.playerSpeed   = EditorGUILayout.Slider("Player speed: ", t.playerSpeed, 1.0f, 100.0f);
        t.levelName     = EditorGUILayout.TextField("Starting level: ", t.levelName); 
    }
}
