using UnityEngine;
using System.Collections;
/// <summary>
/// This component is the pickup/powerup in the game.
/// It uses the ScoreCounter as data store.
/// </summary>
public class PickupCoin : MonoBehaviour {
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<ScoreCounter>().totalPoints += 10;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
			GameObject.Find("UI(Clone)").GetComponent<ScaleInGameGUI>().cCoins++;
        }
    }
}
