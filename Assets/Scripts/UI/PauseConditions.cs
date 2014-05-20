using UnityEngine;
using System.Collections;

public class PauseConditions : MonoBehaviour
{
    void Update()
    {
        // Pause game if less or more than 4 fingers (2 players)
        
#if UNITY_ANDROID
        if (Input.touchCount == 4)
        {
            Time.timeScale = 1.0f;
        }
        else
        {
            Time.timeScale = 0.0f;
        }
#endif
    }
}
