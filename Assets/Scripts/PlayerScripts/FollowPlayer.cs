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
        if (playerObject == null)
        {
            Debug.LogWarning("Player Object is null in: " + this.ToString());
            return;
        }
        transform.position = Vector3.Lerp(playerObject.transform.position - new Vector3(0, 0, 6.18f), transform.position, Mathf.Pow(0.98f, Time.deltaTime * Application.targetFrameRate * 16.1803f));
    }
}
