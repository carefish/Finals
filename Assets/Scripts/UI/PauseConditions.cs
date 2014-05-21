using UnityEngine;
using System.Collections;

public class PauseConditions : MonoBehaviour
{
    void Start()
    {
        //Debug.Log(GameObject.Find("Button1").GetComponent<GUITexture>().texture.height);
        GameObject.Find("Button1").GetComponent<GUITexture>().pixelInset = new Rect(0,
                                                                                   0, 256, 128);
        GameObject.Find("Button2").GetComponent<GUITexture>().pixelInset = new Rect(Screen.width - GameObject.Find("Button2").GetComponent<GUITexture>().pixelInset.width,
                                                                                    0, 256, 128);
        GameObject.Find("Button3").GetComponent<GUITexture>().pixelInset = new Rect(Screen.width - GameObject.Find("Button3").GetComponent<GUITexture>().pixelInset.width,
                                                                                    Screen.height - GameObject.Find("Button3").GetComponent<GUITexture>().pixelInset.height, 256, 128);
        GameObject.Find("Button4").GetComponent<GUITexture>().pixelInset = new Rect(0,
                                                                                    Screen.height - GameObject.Find("Button4").GetComponent<GUITexture>().pixelInset.height, 256, 128);
    }
    void Update()
    {
        // Pause game if less or more than 4 fingers (2 players)
#if UNITY_ANDROID
        if (inputPos(GameObject.Find("Button1")) && inputPos(GameObject.Find("Button2")) &&
           inputPos(GameObject.Find("Button3")) && inputPos(GameObject.Find("Button4")))
        {
            Time.timeScale = 1.0f;
        }
        else
        {
            Time.timeScale = 0.0f;
        }
#endif
    }
#if UNITY_ANDROID
    private bool inputPos(GameObject checkPos)
    {
        foreach (Touch t in Input.touches)
        {
            if (checkPos.GetComponent<GUITexture>().HitTest(t.position))
            {
                return true;
            }
        }
        return false;
    }
#endif
}