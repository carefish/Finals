using UnityEngine;
using System.Collections;
/// <summary>
/// This is a helper class to help with rotating the User Interface elements.
/// </summary>
public class RotateGUI : MonoBehaviour
{
    public Texture2D texture = null;
    public float angle = 0;
    public Vector2 size = new Vector2(128, 128);
    Vector2 pos = new Vector2(0, 0);
    Rect rect;
    Vector2 pivot;

    public RotateGUI(GameObject gameobj)
    {
        size = new Vector2(gameobj.GetComponent<GUITexture>().pixelInset.width,
                           gameobj.GetComponent<GUITexture>().pixelInset.height);
    }
}
