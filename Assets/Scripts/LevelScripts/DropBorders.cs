using UnityEngine;
using System.Collections;

public class DropBorders : MonoBehaviour
{
    public float easeDuration = 16.1803f;
    public float liftDuration = 1.61803f;
    public bool touching = false;

    float liftTimer = 0.5f;
    float startZ;
    float endZ;
    float startTime;
    Vector3 startPosition;

    void Start()
    {
        liftTimer = liftDuration;
        startPosition = transform.position;
    }

    void Update()
    {
        //TODO: fix max height
        //Debug.Log(transform.position.z + " startpos: " + startPosition.z);
        if (transform.position.z > startPosition.z && !touching && Time.time > liftTimer)
        {
            liftTimer = Time.time + liftDuration;
            LiftBlocks();
            SetLiftValues(Time.time);
        }
    }

    public void SetDropValues(float time)
    {
        startTime = time;
        startZ = transform.position.z;
        endZ = startZ + 0.5f;
    }

    public void SetLiftValues(float time)
    {
        if (transform.position.z > startPosition.z)
        {
            return;
        }
        startTime = time;
        startZ = transform.position.z;
        endZ = startZ - 0.5f;
    }

    public void DropBlocks()
    {
        float duration = (Time.time - startTime) / easeDuration;
        float val = Mathf.SmoothStep(startZ, endZ, duration);
        transform.position = new Vector3(transform.position.x, transform.position.y, val);
    }

    public void LiftBlocks()
    {
        float duration = (Time.time - startTime) / liftDuration;
        float val = Mathf.SmoothStep(startZ, endZ, duration);
        transform.position = new Vector3(transform.position.x, transform.position.y, val);
    }
}
