using UnityEngine;
using System.Collections;

public class winNow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter (Collision col)	{
		if(col.collider.name == "obj_Player(Clone)")	{
			Debug.Log("hitting the finish line");
		}
	}
}
