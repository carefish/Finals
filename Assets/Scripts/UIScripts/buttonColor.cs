using UnityEngine;
using System.Collections;

public class buttonColor : MonoBehaviour {
	public string gameState = "_red";
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}
	/// <summary>
	/// Changes the color of UI
	/// </summary>
	/// <param name="gameobj">Gameobj.</param>
	public void changeColor(GameObject gameobj)	{
		gameobj.guiTexture.texture = Resources.Load("Textures/UI/final_ui_colors/btn_" + gameobj.name + GameObject.Find("Camera").GetComponent<PauseConditions>().buttonState + 
		                                            "_" + GameObject.Find("Borders").GetComponent<DropBorders>().signalPlan.ToString() ) as Texture;
	}
}
