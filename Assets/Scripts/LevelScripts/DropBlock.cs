using UnityEngine;
using System.Collections;
/// <summary>
/// Component used to ease a levelpart downwards.
/// Controlled in the editor by DropBlockHelper
/// </summary>
public class DropBlock : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        gameObject.transform.parent.GetComponent<DropBorders>().SetDropValues(Time.time);
        gameObject.transform.parent.GetComponent<DropBorders>().touching = true;
    }

    void OnTriggerStay(Collider other)
    {
        gameObject.transform.parent.GetComponent<DropBorders>().DropBlocks();
        gameObject.transform.parent.GetComponent<DropBorders>().touching = true;
    }

    void OnTriggerExit(Collider other)
    {
        gameObject.transform.parent.GetComponent<DropBorders>().SetDropValues(Time.time);
        gameObject.transform.parent.GetComponent<DropBorders>().touching = false;
        gameObject.transform.parent.GetComponent<DropBorders>().SetLiftValues(Time.time);
    }
}
