using UnityEngine;
using System.Collections;

public class FinishTrigger : MonoBehaviour
{
    public PauseConditions pauseConditions;//is set via Inspector.
    bool switchToMenu = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //pauseConditions.enabled = false;
            switchToMenu = true;
			Debug.Log("this test!");
			GameObject.Find("Final_Screen").GetComponent<WonScreen>().levelWon = true;
        }
    }
		
	void OnColissionEnter(Collision col)	{
		if(col.collider.name == "obj_Player(Clone)" )	{
			Debug.Log("hi man");
		}
	}
    void Update()
    {

        //obj.wincondish = switchtomenu;
    }
}
