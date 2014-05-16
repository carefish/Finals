using UnityEngine;
using System.Collections;

public class PickupCoin : MonoBehaviour {
    void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("obj_Player"))
        {
            other.gameObject.GetComponent<ScoreCounter>().totalPoints += 10;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("obj_Player"))
        {
            Destroy(gameObject);

        }
    }
}
