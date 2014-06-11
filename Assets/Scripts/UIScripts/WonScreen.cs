using UnityEngine;
using System.Collections;
/// <summary>
/// This component is displayed when the player has completed the level.
/// </summary>
public class WonScreen : MonoBehaviour {
	/// <summary>
	/// Check if level has been completed (if players won)
	/// </summary>
	public bool levelWon 	= false;

	// Gameobjects needed for won screen:
	private GUITexture wonBG;
	private GUITexture buttonLvlSelect;
	private GUITexture darkOverlay;
	private GameObject guiWon;
	//---------------------------

	// Texture width & height of won background:
	private float tWidth 	= 457;
	private float tHeight 	= 437;
	//-------------------------------
	// Texture width & height of button levelselect:
	private float bWidth 	= 136;
	private float bHeight 	= 136;
	// Use this for initialization
	void Start () {
		if(!levelWon)	{
			guiWon 		= GameObject.Find("guiWon");
			
			darkOverlay = transform.FindChild("final_overlay").GetComponent<GUITexture>();
			buttonLvlSelect = transform.FindChild("btn_lvlslct_up").GetComponent<GUITexture>();
			wonBG 	= transform.FindChild("ui_popup_final").GetComponent<GUITexture>();
			ScaleInGameGUI getInfo = transform.parent.GetComponent<ScaleInGameGUI>();
			bWidth  *= getInfo.getScaleFactorX();
			bHeight *= getInfo.getScaleFactorY();

			tWidth 	*= getInfo.getScaleFactorX();
			tHeight *= getInfo.getScaleFactorY();
			// wonBG scale:
			wonBG.GetComponent<GUITexture>().pixelInset = new Rect(Screen.width / 2 - tWidth / 2 , Screen.height / 2 - tHeight / 2 , tWidth, tHeight);
			buttonLvlSelect.pixelInset = new Rect(Screen.width / 2 - bWidth / 2 , Screen.height / 2.1f - bHeight , bWidth, bHeight);
			Rect getTextWindow = guiWon.GetComponent<GUIText>().GetScreenRect();
			Debug.Log("textwindow : " + getTextWindow.width);
			guiWon.transform.GetComponent<GUIText>().pixelOffset = new Vector2(Screen.width / 2 - getTextWindow.width / 2, Screen.height / 2 + 100 * wonBG.transform.parent.parent.GetComponent<ScaleInGameGUI>().getScaleFactorY());

			// Set gameobjects off untill player beats the level
			guiWon.SetActive(false);
			darkOverlay.enabled = false;
			wonBG.enabled = false;
			buttonLvlSelect.enabled = false;
			levelWon = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		// Check if players won and boolean is set to true:
		if(levelWon)	{
			// Set gameobjects on true if player beats level:
			guiWon.SetActive(true);
			darkOverlay.enabled = true;
			wonBG.enabled = true;
			buttonLvlSelect.enabled = true;
			//--------------------------------
			if(buttonLvlSelect.HitTest(Input.mousePosition) && Input.GetMouseButtonDown(0))	{
				Application.LoadLevel(0);
			}
			// If player presses return button on Android or escape on PC
			if (Input.GetKeyDown(KeyCode.Escape))	{
				Application.LoadLevel(0);
			}
			Time.timeScale = 0.0f;

		}

	}
}
