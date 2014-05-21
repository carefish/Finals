using UnityEngine;
using System.Collections;

public class BlockTransparency : MonoBehaviour {
    GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
	void Update ()
    {
        Color col = renderer.material.color;
        float dist = Vector3.Distance(player.transform.position, gameObject.transform.position);
        //Debug.Log(player.transform.position); 
        if (dist <= 3.5f)
        {

            Debug.Log("1"); 
            col.a -= 0.1f;
            if (col.a <= 0.0f)
            {
                col.a = 0.0f;
            }
            renderer.material.color = col;
        }
        else
        {
            Debug.Log("0"); 
            col.a += 0.1f;
            if (col.a >= 1.0f)
            {
                col.a = 1.0f;
            }
            renderer.material.color = col;
        }
	}
}
