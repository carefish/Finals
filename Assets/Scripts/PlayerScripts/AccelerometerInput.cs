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
    void Awake()
    {
        gameConfig = GameObject.Find("GameConfig").GetComponent<GameConfig>();
        speed = gameConfig.playerSpeed;
    }

    void FixedUpdate()
    {
        speed = gameConfig.playerSpeed;
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
        rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed, 0.08f * Physics.gravity.z);
#endif
#if UNITY_ANDROID
        rigidbody.velocity = new Vector3(Input.acceleration.x * speed, Input.acceleration.y * speed, 0.08f * Physics.gravity.z);
#endif
    }
}
