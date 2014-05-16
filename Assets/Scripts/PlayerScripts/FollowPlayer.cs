using UnityEngine;
using System.Collections;
/// <summary>
/// This component ensures the Camera follows the player.
/// The playerObject is checked for an active instane as well.
/// </summary>
public class FollowPlayer : MonoBehaviour
{
    public GameObject playerObject;
    
    void Update()
    {
        if (playerObject == null) return;
        transform.position = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y, transform.position.z);
    }
}
