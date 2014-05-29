using UnityEngine;
using System.Collections;
/// <summary>
/// This component allows for transparent transition of a GameObject
/// if some other collider is nearby. In this case the Player.
/// </summary>
public class WaterTransparency : MonoBehaviour
{
    public GameObject player;
    public bool change;

    void Update()
    {
        Color col = transform.renderer.material.color;
        if (change)
        {
            col.a -= 0.016f;
            if (col.a <= 0.16f)
            {
                col.a = 0.16f;
            }
            transform.renderer.material.color = col;
        }
        else
        {
            col.a += 0.1f;
            if (col.a >= 1.0f)
            {
                col.a = 1.0f;
            }
            transform.renderer.material.color = col;
        }
    }
}
