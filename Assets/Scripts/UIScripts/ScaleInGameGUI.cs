using UnityEngine;
using System.Collections;

public class ScaleInGameGUI : MonoBehaviour {
	
	public const int calcSizesWidth = 720;	// testdevice width Size taken
	public const int calcSizesHeight = 1280;	// testdevice height Size taken
	public GameObject barTest;
	public GameObject barTest2;
	public float cCoins;
	private float mCoins;
	// Use this for initialization
	void Start () {

			mCoins = GameObject.FindGameObjectsWithTag("Pickup_Coin").Length;
			foreach (GameObject s in GameObject.FindGameObjectsWithTag("UI_Elements_Buttons_Score")) {
				

				float pixelInsetX = s.GetComponent<GUITexture>().pixelInset.x;
				float pixelInsetY = s.GetComponent<GUITexture>().pixelInset.y;
				float pixelInsetW = s.GetComponent<GUITexture>().pixelInset.width;
				float pixelInsetH = s.GetComponent<GUITexture>().pixelInset.height;
				s.GetComponent<GUITexture>().pixelInset = new Rect(pixelInsetX * getScaleFactorX() ,pixelInsetY * getScaleFactorY(), pixelInsetW * getScaleFactorX(), pixelInsetH * getScaleFactorX());
			}
			GameObject.Find("Pause_Screen").GetComponent<GUITexture>().pixelInset = new Rect(Screen.width / 2 - 457 * getScaleFactorX() / 2, Screen.height / 2 - 367 * getScaleFactorY() / 2, 457 * getScaleFactorX(), 367 * getScaleFactorY() );
			GameObject.Find("btn_tutorial").GetComponent<GUITexture>().pixelInset = new Rect(Screen.width / 1.5f - 136 * getScaleFactorX() / 1.5f, Screen.height / 2 - 138 * getScaleFactorY() / 2, 136 * getScaleFactorX(), 138 * getScaleFactorY() );
			GameObject.Find("btn_lvlSelect").GetComponent<GUITexture>().pixelInset = new Rect(Screen.width / 2.5f - 136 * getScaleFactorX() / 1.8f, Screen.height / 2 - 138 * getScaleFactorY() / 2, 136 * getScaleFactorX(), 138 * getScaleFactorY() );

	}
	
	// Update is called once per frame
	void Update () {
		// Fills the bar
			barTest = GameObject.Find("ui_Score_BarFiller")	;		
			barTest.GetComponent<GUITexture>().pixelInset = new Rect((float)(Screen.width / 2) - (barTest.GetComponent<GUITexture>().pixelInset.width / 2), 13 * getScaleFactorY(), scaleBar(), 15f * getScaleFactorX());

			barTest2 = GameObject.Find("ui_Score_BarFiller2");
			barTest2.GetComponent<GUITexture>().pixelInset = new Rect((float)(Screen.width / 2) - (barTest2.GetComponent<GUITexture>().pixelInset.width / 2), Screen.height - 13 * getScaleFactorY(), scaleBar(), 15f * getScaleFactorX() *-1);
			



	}
	/// <summary>
	/// Scales the bar according to the score and resolution
	/// </summary>
	/// <returns>The bar.</returns>
	private float scaleBar()	{
		float mWidth = 230 * getScaleFactorX();


		//float xPos	 = 245 * getScaleFactorX();
		//float yPos	 = 12 * getScaleFactorY();
		 	
		// Collected coins (current coins)
		//GameObject.Find("GameConfig").GetComponent<GameConfig>().
		//float cCoins 	= 2;
		float perCoin = mWidth / mCoins;
		return perCoin * cCoins;
		 
	}

	/// <summary>
	/// Get scale factor X based on base width (1280)
	/// </summary>
	/// <returns>The scale factor x.</returns>
	float getScaleFactorX()
	{
		float scaleFactorX = (float)Screen.width / calcSizesWidth;
		return scaleFactorX;
	}
	/// <summary>
	/// Get Scale factor Y based on base height (720)
	/// </summary>
	/// <returns>The scale factor y.</returns>
	float getScaleFactorY()
	{
		float scaleFactorY = (float)Screen.height / calcSizesHeight;
		return scaleFactorY;
	}
}
