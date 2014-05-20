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
        BroadcastMessage("DropDown");
    }

    public void DropDown()
    {
        float duration = (Time.time - startTime) / easeDuration;
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.SmoothStep(startZ, endZ, duration));
    }

    //void OnTriggerExit(Collider other)
    //{
    //    SetTransitionValues();
    //}

    public void SetTransitionValues()
    {
        startZ = transform.position.z;
        endZ = startZ + 0.5f;
    }

}
