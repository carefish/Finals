using UnityEngine;
using System.Collections;

public class WonScreen : MonoBehaviour {
	// Gameobjects needed for won screen:
	private GameObject wonBG;
	private GameObject button_LvlSelect;
	private GameObject darkOverlay;
	private GameObject guiWon;
	//---------------------------
	/// <summary>
	/// Check if level has been completed (if players won)
	/// </summary>
	public bool levelWon 	= false;
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
			darkOverlay = GameObject.Find("final_overlay");
			button_LvlSelect = GameObject.Find("btn_lvlslct_up");
			wonBG 	= GameObject.Find("ui_popup_final");
			bWidth  *= wonBG.transform.parent.parent.GetComponent<ScaleInGameGUI>().getScaleFactorX();
			bHeight *= wonBG.transform.parent.parent.GetComponent<ScaleInGameGUI>().getScaleFactorY();

			tWidth 	*= wonBG.transform.parent.parent.GetComponent<ScaleInGameGUI>().getScaleFactorX();
			tHeight *= wonBG.transform.parent.parent.GetComponent<ScaleInGameGUI>().getScaleFactorY();
			// wonBG scale:
			wonBG.GetComponent<GUITexture>().pixelInset = new Rect(Screen.width / 2 - tWidth / 2 , Screen.height / 2 - tHeight / 2 , tWidth, tHeight);
			button_LvlSelect.GetComponent<GUITexture>().pixelInset = new Rect(Screen.width / 2 - bWidth / 2 , Screen.height / 2.1f - bHeight , bWidth, bHeight);
			Rect getTextWindow = guiWon.GetComponent<GUIText>().GetScreenRect();
			Debug.Log("textwindow : " + getTextWindow.width);
			guiWon.GetComponent<GUIText>().pixelOffset = new Vector2(Screen.width / 2 - getTextWindow.width / 2, Screen.height / 2 + 100 * wonBG.transform.parent.parent.GetComponent<ScaleInGameGUI>().getScaleFactorY());
			//guiWon.GetComponent<MeshRenderer>().renderer.bounds.size.Set(guiWon.GetComponent<MeshRenderer>().renderer.bounds.size.x / 2, guiWon.GetComponent<MeshRenderer>().renderer.bounds.size.y, 0);
			guiWon.SetActive(false);
			// Set gameobjects off
			darkOverlay.SetActive(false);
			wonBG.SetActive(false);
			button_LvlSelect.SetActive(false);
			levelWon = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		// Check if players won and boolean is set to true:
		if(levelWon)	{
			// Set gameobjects on
			guiWon.SetActive(true);
			darkOverlay.SetActive(true);
			wonBG.SetActive(true);
			button_LvlSelect.SetActive(true);
			if(button_LvlSelect.GetComponent<GUITexture>().HitTest(Input.mousePosition) && Input.GetMouseButtonDown(0))	{
				Application.LoadLevel(0);
			}
			if (Input.GetKeyDown(KeyCode.Escape))	{
				Application.LoadLevel(0);
			}
			Time.timeScale = 0.0f;

		}

	}
}
