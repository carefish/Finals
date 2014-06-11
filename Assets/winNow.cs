using UnityEngine;
using System.Collections;

public class winNow : MonoBehaviour
{

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.name == "obj_Player(Clone)")
        {
            Debug.Log("hitting the finish line");
        }
    }
}
