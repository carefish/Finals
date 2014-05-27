using UnityEngine;
using System.Collections;

public class BlockRecycler : MonoBehaviour
{
    Vector3 startPosition;
    Vector3 recyclePosition;

    void Start()
    {
        startPosition = transform.position;
        recyclePosition = startPosition;
        recyclePosition.z += 1000.0f;
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;
        if (startPosition.z != currentPosition.z)
        {
            transform.position = recyclePosition;
        }
        else
        {
            transform.position = startPosition;
        }
    }
}
