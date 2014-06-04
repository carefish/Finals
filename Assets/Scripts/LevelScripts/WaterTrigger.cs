using UnityEngine;
using System.Collections;
/// <summary>
/// This component manages the transparency of the water mesh in the game.
/// </summary>
public class WaterTrigger : MonoBehaviour {
    WaterTransparency t;
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
