using UnityEngine;
using System.Collections;
/// <summary>
/// Helper class to quickly go back to the main screen.
/// </summary>
public class goToMenu : MonoBehaviour
{
    void Update()
    {
        if (this.gameObject.GetComponent<GUITexture>().HitTest(Input.mousePosition) && Input.GetMouseButtonDown(0))
        {
            Application.LoadLevel(0);
        }
    }
}
