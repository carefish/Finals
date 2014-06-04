using UnityEngine;
using System.Collections;
/// <summary>
/// This component allows for transparent transition of a GameObject
/// if some other collider is nearby. In this case the Player.
/// </summary>
public class BlockTransparency : MonoBehaviour
{
    public GameObject player;
    public float distanceTillFade = 2.5f;
    void Update()
    {
        Color col = transform.parent.renderer.material.color;
        float dist = Vector3.Distance(player.transform.position, transform.position);
        //op de z as checken. als de parent van de transform zijn z kleiner is dan de speler z dan zit de speler erboven.

        if (dist <= distanceTillFade && player.transform.position.z >= transform.parent.position.z)
        {
            col.a -= 0.1f;
            if (col.a <= 0.0f)
            {
                col.a = 0.0f;
            }
            transform.parent.renderer.material.color = col;
        }
        else
        {
            col.a += 0.1f;
            if (col.a >= 1.0f)
            {
                col.a = 1.0f;
            }
            transform.parent.renderer.material.color = col;
        }

    }
}
