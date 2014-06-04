using UnityEngine;
using System.Collections;

/// <summary>
/// This component allows the application to exit on any platform.
/// </summary>
public class ApplicationExit : MonoBehaviour
{
    void Update()
    {
		#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
		#endif
    }
}
