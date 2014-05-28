using UnityEngine;
using System.Collections;
public enum SignalPlan
{
    GREEN,
    ORANGE,
    RED,
}

/// <summary>
/// This component lowers or raises the borders as one object.
/// This component is dependent on DropBlock's interaction with the player.
/// </summary>
public class DropBorders : MonoBehaviour
{
    public float liftDuration = 1.61803f;
    public SignalPlan signalPlan;
    float counter = 0f;
    float startTime;
    float startZ;
    float endZ;
    Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
        Debug.Log("start: " + startPosition.z);
    }
    void Update()
    {
        counter += Time.deltaTime;
        if (counter > liftDuration && transform.position.z > startPosition.z)
        {
            Debug.Log("border: " + transform.position.z + " | " + counter);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.005f);
            counter = 0f;
        }
        if (transform.position.z <= startPosition.z)
        {
            signalPlan = SignalPlan.GREEN;
        } else if (transform.position.z <= startPosition.z + .5f)
        {
            signalPlan = SignalPlan.ORANGE;
        } else if (transform.position.z <= startPosition.z + 1f)
        {
            signalPlan = SignalPlan.RED;
        }
    }

    public void SetLiftValues(float time)
    {
        startTime = time;
        startZ = transform.position.z;
        endZ = startZ - 0.5f;
    }

    public void LiftBlocks()
    {
        float duration = (Time.time - startTime) / liftDuration;
        float val = Mathf.SmoothStep(startZ, endZ, duration);
        transform.position = new Vector3(transform.position.x, transform.position.y, val);
    }
}
