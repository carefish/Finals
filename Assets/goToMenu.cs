using UnityEngine;
using System.Collections;

public class goToMenu : MonoBehaviour {

    void Update()
    {
		if(this.gameObject.GetComponent<GUITexture>().HitTest(Input.mousePosition) && Input.GetMouseButtonDown(0))	{
            Application.LoadLevel(0);
		}
    }
}
