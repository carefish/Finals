using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// This component allows the buttons to change color based on the height of the borders.
/// It
/// </summary>
public class buttonColor : MonoBehaviour
{
	// Testing texture array for faster acces times:
	public Texture[] testTextureArray;
    public string gameState = "_red";
	public void Start()	{
        testTextureArray = Resources.LoadAll("Textures/UI/final_ui_colors") as Texture[];
	}
    /// <summary>
    /// Changes the color of UI
    /// </summary>
    /// <param name="gameobj">Gameobj.</param>
    public void changeColor(GUITexture gameObjTexture)	{
		gameObjTexture.texture = getTexture("btn_" + gameObjTexture.gameObject.name + GameObject.Find("Camera").GetComponent<PauseConditions>().buttonState + "_" + GameObject.Find("Borders").GetComponent<DropBorders>().signalPlan.ToString());
		//gameObjTexture.texture = Resources.Load("Textures/UI/final_ui_colors/btn_" + gameObjTexture.gameObject.name + GameObject.Find("Camera").GetComponent<PauseConditions>().buttonState +
                                                   // "_" + GameObject.Find("Borders").GetComponent<DropBorders>().signalPlan.ToString()) as Texture;
    }
	private Texture getTexture(string nameOfTexture)	{
		for (int i = 0; i < testTextureArray.Length; i++) {
			if(testTextureArray[i].name.Equals(nameOfTexture))	{
				return testTextureArray[i];
			}
		}
		return testTextureArray[0];

	}
}
