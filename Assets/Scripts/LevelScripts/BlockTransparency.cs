using UnityEngine;
using System.Collections;
/// <summary>
/// This component allows for transparent transition of a GameObject
/// if some other collider is nearby. In this case the Player.
/// </summary>
public class BlockTransparency : MonoBehaviour
{
    public GameObject player;
    bool change = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            change = false; 
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Color col = transform.parent.renderer.material.color;
            col.a += 0.1f;
            if (col.a >= 1.0f)
            {
                col.a = 1.0f;
            }
            transform.parent.renderer.material.color = col;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            change = true; 
        }
    }

    void Update()
    {
        Color col = transform.parent.renderer.material.color;
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist <= 3.5f && change)
        {
            //Debug.Log("1");
            col.a -= 0.1f;
            if (col.a <= 0.0f)
            {
                col.a = 0.0f;
            }
            transform.parent.renderer.material.color = col;
        }
        else
        {
            //Debug.Log("0");
            col.a += 0.1f;
            if (col.a >= 1.0f)
            {
                col.a = 1.0f;
            }
            transform.parent.renderer.material.color = col;
        }
    }
}
