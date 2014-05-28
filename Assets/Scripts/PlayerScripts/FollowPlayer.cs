using UnityEngine;
using System.Collections;
/// <summary>
/// This component ensures the Camera follows the player.
/// The playerObject is checked for an active instane as well.
/// </summary>
public class FollowPlayer : MonoBehaviour
{
    public GameObject playerObject;
    //SpringJoint springJoint;
    void Start()
    {
        //gameObject.AddComponent<Rigidbody>();
        //gameObject.rigidbody.useGravity = false;
        //springJoint = gameObject.AddComponent<SpringJoint>();
        //springJoint.connectedBody = playerObject.rigidbody;
        //springJoint.connectedAnchor = playerObject.transform.position;
        //springJoint.maxDistance = 1.6f;
        //springJoint.minDistance = 1.0f;
    }
    void Update()
    {
        if (playerObject == null)
        {
            Debug.LogWarning("Player Object is null in: " + this.ToString());
            return;
        }
        transform.position = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y, transform.position.z);

        //springJoint.anchor = gameObject.transform.position;
    }
}
