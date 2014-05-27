using UnityEngine;
using System.Collections;

public class ScaleInGameGUI : MonoBehaviour {
	
	public const int calcSizesWidth = 720;	// testdevice width Size taken
	public const int calcSizesHeight = 1280;	// testdevice height Size taken
	// Use this for initialization
	void Start () {

		foreach (GameObject s in GameObject.FindGameObjectsWithTag("UI_Elements_Buttons_Score")) {
			Debug.Log("test p1");

			float pixelInsetX = s.GetComponent<GUITexture>().pixelInset.x;
			float pixelInsetY = s.GetComponent<GUITexture>().pixelInset.y;
			float pixelInsetW = s.GetComponent<GUITexture>().pixelInset.width;
			float pixelInsetH = s.GetComponent<GUITexture>().pixelInset.height;
			s.GetComponent<GUITexture>().pixelInset = new Rect(pixelInsetX * getScaleFactorX() ,pixelInsetY * getScaleFactorY(), pixelInsetW * getScaleFactorX(), pixelInsetH * getScaleFactorX());
		}


	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(Screen.width.ToString() + "\t" + Screen.height.ToString());
	}
	private void scaleBar()	{
		float mWidth = 230 * getScaleFactorX();
		float xPos	 = 245 * getScaleFactorX();
		float yPos	 = 12 * getScaleFactorY();
		int mCoins = 10;
		int cCoins = 2;
		float perCoin = mWidth / cCoins;



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
