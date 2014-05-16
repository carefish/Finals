using UnityEngine;
using System.Collections;
/// <summary>
/// Component used to ease a levelpart downwards.
/// Controlled in the editor by DropBlockHelper
/// </summary>
public class DropBlock : MonoBehaviour
{
    public float easeDuration = 16.1803f;
    float startZ;
    float endZ;
    float startTime;

    void Start()
    {
        
        SetTransitionValues();
    }

    void OnTriggerEnter(Collider other)
    {
        startTime = Time.time;
    }
    void OnTriggerStay(Collider other)
    {
        //Debug.Log("stay " + easeDuration);

        float duration = (Time.time - startTime) / easeDuration;
        //Debug.Log(string.Format("easeDur: {0} dur: {1}", easeDuration, duration));
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.SmoothStep(startZ, endZ, duration));
    }

    void OnTriggerExit(Collider other)
    {
        SetTransitionValues();
    }

    void SetTransitionValues()
    {
        startZ = transform.position.z;
        endZ = startZ + 0.5f;
    }

}
