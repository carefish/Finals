using UnityEngine;
using System.Collections;
/// <summary>
/// This component allows the game to pause if the players are not playing the game properly
/// or if they want to take a break. Or if the supervising mentor wants to intervene.
/// </summary>
public class PauseConditions : MonoBehaviour
{
	// UI Buttons:
	public GUITexture button1;
	public GUITexture button2;
	public GUITexture button3;
	public GUITexture button4;
	
	//Button state (pressed or not)
	public string buttonState = "up";
	// Pause Button
	private GameObject pauseTxt1;
	private GameObject pauseTxt2;
	private GameObject pScreen;
	private float highScoreX;
	void Update()
	{
		//----------------
		#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
			pressLevelSelect(GameObject.Find("btn_lvlSelect"));
		#endif
		
		#if UNITY_ANDROID
		// Pause game if less or more than 4 fingers (2 players)
		if (inputPos(button1) & inputPos(button2) &
		    inputPos(button3) & inputPos(button4))
		{
			GameObject.Find("UI(Clone)").GetComponent<buttonColor>().changeColor(button1);
			// Check if pause screen is not disabled else disable 
			if(GameObject.Find("Pause_Screen") != null && GameObject.Find("Pause_Screen").activeSelf)
			{
				pScreen = GameObject.Find("Pause_Screen");
				pScreen.SetActive(false);
			}
			Time.timeScale = 1.0f;
			if(GameObject.Find(pauseTxt1.name))	{
				Destroy(GameObject.Find(pauseTxt1.name));
				Destroy(GameObject.Find(pauseTxt2.name));
			}
		}
		// Check howmay fingers are on the display (4)
		else if(Application.platform == RuntimePlatform.Android && Input.touchCount != 4)
		{
			// Pause game
			Time.timeScale = 0.0f;
			// set pause screen to true and display pause text
			pScreen.SetActive(true);
			showPauseText();
			//GameObject.Find("Pause_Screen").SetActive(true);
			
		}
		#endif
	}
	private void pressLevelSelect(GameObject checkPos)	{
		foreach (Touch t in Input.touches) {
			if(checkPos.GetComponent<GUITexture>().HitTest(t.position))	{
				Application.LoadLevel(0);
			}
		}
		
	}
	/// <summary>
	/// Checks if Touch Input touches given Gameobject
	/// </summary>
	/// <returns><c>true</c>if finger touches gameobject <c>false</c> otherwise false</returns>
	/// <param name="checkPos">Check position.</param>
	private bool inputPos(GUITexture checkPos)
	{
		foreach (Touch t in Input.touches)
		{
			if(checkPos.GetComponent<GUITexture>().pixelInset.width < 0 || 
			   checkPos.GetComponent<GUITexture>().pixelInset.height < 0)	{
				if(t.position.x > checkPos.pixelInset.x  + checkPos.GetComponent<GUITexture>().pixelInset.width &&
				   t.position.x < checkPos.pixelInset.x &&
				   t.position.y > checkPos.pixelInset.y + checkPos.GetComponent<GUITexture>().pixelInset.height && 
				   t.position.y < checkPos.pixelInset.y )	{
					buttonState = "_down";
					GameObject.Find("UI(Clone)").GetComponent<buttonColor>().changeColor(checkPos);
					return true;

				}
				
			}
			else {
				if(checkPos.HitTest(t.position))	{
					buttonState = "_down";
					GameObject.Find("UI(Clone)").GetComponent<buttonColor>().changeColor(checkPos);
					return true;
				}
			}
		}
		buttonState = "_up";
		GameObject.Find("UI(Clone)").GetComponent<buttonColor>().changeColor(checkPos);
		return false;
	}
	/// <summary>
	/// Displays Pause Text on screen when paused
	/// </summary>
	private void showPauseText()	{
		string loadThisResourceText = "LevelParts/Text_test";
		//GameObject pauseTxt1 = testpausetxt;
		//GameObject pauseTxt2;
		
		try {
			highScoreX = (pauseTxt1.GetComponentInChildren<MeshRenderer>().renderer.bounds.size.x / 2);
			pauseTxt1.GetComponent<Transform>().transform.localScale = new Vector3(0.01f, 0.1f, 0.01f);
			pauseTxt2.GetComponent<Transform>().transform.localScale = new Vector3(-0.01f, 0.1f, 0.01f);
			pauseTxt2.transform.rotation = Quaternion.Euler(new Vector3(pauseTxt2.transform.rotation.eulerAngles.x, 
			                                                            pauseTxt2.transform.rotation.eulerAngles.y
			                                                            ,pauseTxt2.transform.rotation.eulerAngles.z)); // pauseTxt2.transform.localRotation.eulerAngles.x
			pauseTxt1.transform.position = new Vector3(this.transform.position.x - highScoreX, this.transform.position.y - 0.12f, this.transform.position.z + 0.35f);
			pauseTxt2.transform.position = new Vector3(this.transform.position.x + highScoreX, this.transform.position.y + 0.12f, this.transform.position.z + 0.35f);
			if(pauseTxt1.transform.rotation.eulerAngles.x  < 357)	{
				Debug.Log("rotatoin works!");
				// 2.6f is minimum for text rotation
				pauseTxt1.transform.localRotation = Quaternion.Euler(new Vector3(pauseTxt1.transform.rotation.eulerAngles.x + .8f,
				                                                                 pauseTxt1.transform.rotation.eulerAngles.y,
				                                                                 pauseTxt1.transform.rotation.eulerAngles.z));
			}
			if(pauseTxt1.transform.rotation.eulerAngles.x > -90)	{
				Debug.Log("test");
				pauseTxt2.transform.localRotation = Quaternion.Euler(new Vector3(pauseTxt2.transform.rotation.eulerAngles.x - .8f,
				                                                                 pauseTxt2.transform.rotation.eulerAngles.y,
				                                                                 pauseTxt2.transform.rotation.eulerAngles.z));
			}
			Debug.Log(pauseTxt1.transform.rotation.eulerAngles);
		} catch (System.Exception ex) {
			Debug.Log(ex);
			pauseTxt1 = Instantiate(Resources.Load(loadThisResourceText)) as GameObject;
			pauseTxt1.name = pauseTxt1.GetComponentInChildren<TextMesh>().text + 1;
			pauseTxt2 = Instantiate(Resources.Load(loadThisResourceText)) as GameObject;
			pauseTxt2.name = pauseTxt2.GetComponentInChildren<TextMesh>().text + 2;
		}
		
	}
}