using UnityEngine;
using System.Collections;
/// <summary>
/// This component recycles objects by placing them 1000f units away
/// on the Z-axis.
/// </summary>
public class BlockRecycler : MonoBehaviour
{
    Vector3 startPosition;
    Vector3 recyclePosition;
    DropBorders dropBorders;
    void Start()
    {
        dropBorders = transform.parent.GetComponent<DropBorders>();
        startPosition = transform.position;
        recyclePosition = startPosition;
        recyclePosition.z += 1000.0f;
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;
        if (dropBorders.signalPlan == SignalPlan.GREEN)
        {
            transform.position = startPosition;
        }
        else if (dropBorders.signalPlan == SignalPlan.ORANGE)
        {
            transform.position = recyclePosition;
        }
        else if (dropBorders.signalPlan == SignalPlan.RED)
        {
            transform.position = recyclePosition;
        }
    }
}
