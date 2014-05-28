using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This component controls the obj_Player by measuring the accelerometer input if played on Android
/// otherwise this function controls obj_Player via W A S D and arrow keys.
/// </summary>
public class AccelerometerInput : MonoBehaviour
{
    float speed = 1.61803f;
    GameConfig gameConfig;
    //TEMP stuff
    GameObject gravtext;
    GameObject speedtext;
    float grav;
    float w = Screen.width * 0.25f;
    float h = Screen.height * 0.25f;
    //END OF TEMP stuff
    void Awake()
    {
        gameConfig = GameObject.Find("GameConfig").GetComponent<GameConfig>();
        speed = gameConfig.playerSpeed;
        //TEMP stuff
        grav = Physics.gravity.z;
        gravtext = GameObject.Find("playerspeedText");
        speedtext = GameObject.Find("gravText");
        //END OF TMEP stuff
    }

    void OnGUI()
    {
        gameConfig.playerSpeed = GUI.VerticalSlider(new Rect(20.0f, 40.0f + h, w, h), gameConfig.playerSpeed, 0.5f, 16.18f);
        //TEMP stuff
        grav = GUI.VerticalSlider(new Rect(Screen.width - 40.0f, 40.0f + h, w, h), grav, 9.81f, 98.1f);
        speedtext.guiText.text = gameConfig.playerSpeed.ToString();
        gravtext.guiText.text = grav.ToString();
        //END OF TEMP stuff
    }

    void FixedUpdate()
    {
        //TEMP stuff
        Physics.gravity = new Vector3(0, 0, grav);
        //END OF TEMP stuff
        speed = gameConfig.playerSpeed;
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
        rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed, 0);
#endif
#if UNITY_ANDROID
        rigidbody.velocity = new Vector3(Input.acceleration.x * speed, Input.acceleration.y * speed, 0);
#endif
    }
}
