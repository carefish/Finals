using UnityEngine;
using System.Collections;
/// <summary>
/// This component is responsible for displaying the tutorial screen.
/// 
/// </summary>
public class tutorialPressed : MonoBehaviour
{
    private GameObject Screen_Tutorial;
    void Start()
    {
        Screen_Tutorial = GameObject.Find("tutorial_bg");
        Screen_Tutorial.GetComponent<GUITexture>().pixelInset = new Rect(0, 0, Screen.width, Screen.height);
        Screen_Tutorial.SetActive(false);
    }

    void Update()
    {
        if (this.gameObject.GetComponent<GUITexture>().HitTest(Input.mousePosition) && Input.GetMouseButtonDown(0))
        {
            Screen_Tutorial.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Screen_Tutorial.SetActive(false);
        }
    }
}
