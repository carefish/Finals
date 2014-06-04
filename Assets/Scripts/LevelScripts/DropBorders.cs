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
    float redCounter = 0f;
    float startTime;
    float startZ;
    float endZ;
    public Vector3 startPosition;
    public Vector3 midPosition;
    public Vector3 endPosition;
    void Start()
    {
        startPosition = transform.position;
        midPosition = startPosition;
        midPosition.z += 0.5f;
        endPosition = startPosition;
        endPosition.z += 1.01f;
        Debug.Log("start: " + startPosition.z);
    }

    void Update()
    {
        if (transform.position.z <= startPosition.z)
        {
            signalPlan = SignalPlan.GREEN;
        }
        else if (transform.position.z <= startPosition.z + .5f)
        {
            signalPlan = SignalPlan.ORANGE;
        }
        else if (transform.position.z <= startPosition.z + 1f)
        {
            signalPlan = SignalPlan.RED;
        }
        counter += Time.deltaTime;
        if (counter > liftDuration && transform.position.z > startPosition.z)
        {
            Debug.Log("pos: " + transform.position.z + " endpos: " + endPosition.z);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.08f);
            counter = 0f;
        }
        else if (counter > liftDuration && transform.position.z > startPosition.z && signalPlan == SignalPlan.RED)
        {
            transform.position = endPosition;
            counter = 0f;
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
