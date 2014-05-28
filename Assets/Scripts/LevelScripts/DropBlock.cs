using UnityEngine;
using System.Collections;
/// <summary>
/// Component used to ease a levelpart downwards.
/// Controlled in the editor by DropBlockHelper
/// </summary>
public class DropBlock : MonoBehaviour
{
    Vector3 downwardsVector = new Vector3(0, 0, 0.005f);

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.transform.parent.position += downwardsVector;
        }
    }
}
