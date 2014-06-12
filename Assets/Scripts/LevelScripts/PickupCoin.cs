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
			#if UNITY_ANDROID
            other.gameObject.GetComponent<ScoreCounter>().totalPoints += 10;
			#endif
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
			#if UNITY_ANDROID
				GameObject.Find("UI(Clone)").GetComponent<ScaleInGameGUI>().cCoins++;
			#endif
        }
    }
}
