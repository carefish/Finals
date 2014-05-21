using UnityEngine;
using System.Collections;
/// <summary>
/// This component ensures the level resets the player.
/// </summary>
public class ResetPlayer : MonoBehaviour
{
    Vector3 spawnPoint;
    void Start()
    {
        spawnPoint = GetComponent<SpawnPoint>().spawnPoint.position;
    }
    /// <summary>
    /// This component allows the player to be 'respawned', by resetting its position.
    /// </summary>
    /// <param name="other">The exiting player object</param>
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = spawnPoint;
        }
    }
}
