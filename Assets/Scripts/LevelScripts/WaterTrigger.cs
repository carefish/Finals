using UnityEngine;
using System.Collections;

public class WaterTrigger : MonoBehaviour {
    WaterTransparency t;
	// Use this for initialization
	void Start () {
        t = transform.parent.GetComponent<WaterTransparency>();
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            t.change = true;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            t.change = true;

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            t.change = false;
        }
    }
}
