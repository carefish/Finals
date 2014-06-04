using UnityEngine;
using System.Collections;
/// <summary>
/// Component used to ease a levelpart downwards.
/// Controlled in the editor by DropBlockHelper
/// </summary>
public class DropBlock : MonoBehaviour
{
    Vector3 downwardsVector = new Vector3(0, 0, 0.08f);
    Vector3 endPosition;
    SignalPlan signalPlan;
    void Start()
    {
        endPosition = transform.parent.GetComponent<DropBorders>().endPosition;
        signalPlan = transform.parent.GetComponent<DropBorders>().signalPlan;
    }
    

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.parent.position += downwardsVector;
        }
    }
}
