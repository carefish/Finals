using UnityEngine;
using System.Collections;
/// <summary>
/// This component is responsible for the main menu in the game.
/// This component is also the entry point for many of the User Interface elements
/// </summary>
public class MenuScript : MonoBehaviour
{
    // All assets (gameobjects) needed for main menu:
	// Screen menu assets:
	private GUITexture button_Credits;
	private GUITexture screen_Credits;
	//Level Select assets:
    private GUITexture button_LvlSelect;
	private GUITexture screen_LvlSelect;
	private GUITexture screen_Menu;
	private GUITexture button_lvlUnlocked;
	private GUITexture lvlSelectEmpty;
	private GUITexture lvlSelectNotCompleted;

	// tutorial Assets:
	private GUITexture button_Tutorial;
	private GUITexture screen_Tutorial;

    /// <summary>
    /// Which Screen is currently visible to the user (tutorial, menu or credits)
    /// </summary>
    private int switchScreens = 0;

    // These are Full HD (1920 x 1080 display)
    public const int calcSizesWidth 	= 1080;	// testdevice width Size taken
    public const int calcSizesHeight 	= 1920;	// testdevice height Size taken
	private float saveScaleFactorX;
	private float saveScaleFactorY;
	// Depth of Buttons:
	private Vector3 screenDepth 		= new Vector3(0, 0, 3);
	private Vector3 lvlSButtonsDepth 	= new Vector3(0, 0, 4);
	private Vector3 resetMenuLayers		= new Vector3(0, 0, 0);
    void Start()
    {
		saveScaleFactorX = getScaleFactorX();
		saveScaleFactorY = getScaleFactorY();
		

        //-------- Setup gameobjects to variables: --------\\
        button_Credits 		= GameObject.Find("btn_credit_up").GetComponent<GUITexture>();
		screen_Credits 		= GameObject.Find("Menu_CreditScreen").GetComponent<GUITexture>();
		button_LvlSelect 	= GameObject.Find("btn_play_up").GetComponent<GUITexture>();
		screen_LvlSelect 	= GameObject.Find("Menu_LvlSelect").GetComponent<GUITexture>();
		button_Tutorial 	= GameObject.Find("btn_tutorial_up").GetComponent<GUITexture>();
		screen_Tutorial 	= GameObject.Find("Menu_tutorial_bg").GetComponent<GUITexture>();
		button_lvlUnlocked 	= GameObject.Find("level_unlock").GetComponent<GUITexture>();
		screen_Menu 		= GameObject.Find("Menu_start_bg").GetComponent<GUITexture>();
		lvlSelectEmpty 		= GameObject.Find("level_empty").GetComponent<GUITexture>();
        //---------------- End of Setup ----------------\\
		// Set Scaling of pixels correctly:
        screen_Menu.pixelInset 			= new Rect(0, 0, Screen.width, Screen.height);

		button_Credits.pixelInset 		= new Rect(100 * saveScaleFactorX, 1100 * saveScaleFactorY, 272 * saveScaleFactorX, 272 * saveScaleFactorX);

		button_LvlSelect.pixelInset 	= new Rect(400 * saveScaleFactorX, 1100 * saveScaleFactorY, 272 * saveScaleFactorX, 272 * saveScaleFactorX);

		button_Tutorial.pixelInset 		= new Rect(700 * saveScaleFactorX, 1100 * saveScaleFactorY, 272 * saveScaleFactorX, 272 * saveScaleFactorX);

		button_lvlUnlocked.pixelInset 	= new Rect(272 * saveScaleFactorX, -2000 * saveScaleFactorY, 272 * saveScaleFactorX, 206 * saveScaleFactorX);

		lvlSelectEmpty.pixelInset 		= new Rect(272 * saveScaleFactorX, -2600 * saveScaleFactorY, 272 * saveScaleFactorX, 206 * saveScaleFactorX);
		//-----------------------------
    }


    void Update()
    {
        // Reset screen to main menu when back button pressed on Android Phone:
        if (Input.GetKeyDown(KeyCode.Escape))
        {
			switchScreens				 			= 0;
            screen_Menu.transform.position 			= new Vector3(0, 0, 1);
			screen_LvlSelect.transform.position 	= resetMenuLayers;
			screen_Credits.transform.position 		= resetMenuLayers;
			button_lvlUnlocked.transform.position 	= resetMenuLayers;
			screen_Tutorial.transform.position 		= resetMenuLayers;
			Rect resetRect							= new Rect(0,0,0,0);
			screen_Tutorial.pixelInset 				= resetRect;
			screen_LvlSelect.pixelInset 			= resetRect;
            button_lvlUnlocked.pixelInset 			= new Rect(Screen.width / 2 - button_lvlUnlocked.pixelInset.width / 2, -2000, button_lvlUnlocked.pixelInset.width, button_lvlUnlocked.pixelInset.height);

            screen_Credits.pixelInset 				= new Rect(0, 0, 0,  Screen.height);

			lvlSelectEmpty.pixelInset 				= new Rect(272 * saveScaleFactorX, -2600 * saveScaleFactorY, 272 * saveScaleFactorX, 206 * saveScaleFactorX);
            
        }

        // Goto Credit screen:
		if (HitTest(button_Credits))
		{
			screen_Credits.transform.position = screenDepth;
			switchScreens = 2;
        }
        // Goto Level Select screen:
		if (HitTest(button_LvlSelect))
        {
			screen_LvlSelect.transform.position 	= screenDepth;
			button_lvlUnlocked.transform.position 	= lvlSButtonsDepth;
			lvlSelectEmpty.transform.position 		= lvlSButtonsDepth;
			switchScreens = 1;
        }
        // If Level Unlocked play this level (currently no other levels so no unlockable as of yet):
        if (HitTest(button_lvlUnlocked))
        {
            // loads Level 1:
            Application.LoadLevel(2);
        }
        if (HitTest(lvlSelectEmpty))
        {
            // Loads test Level:
            Application.LoadLevel(1);
        }
        // Goto Tutorial Screen if Pressed:
        if (HitTest(button_Tutorial))
        {
			screen_Tutorial.transform.position = screenDepth;
			switchScreens = 3;

        }
		// Checks which menu screen is currently active and sets position of assets correctly :
		switch (switchScreens) {
			case 1:
				screen_LvlSelect.pixelInset 	= new Rect(Screen.width - screen_LvlSelect.pixelInset.width, 0, scaleTexture(screen_LvlSelect.pixelInset.width, Screen.width), scaleTexture(screen_LvlSelect.pixelInset.height, Screen.height));

				button_lvlUnlocked.pixelInset 	= new Rect(Screen.width / 2 - button_lvlUnlocked.pixelInset.width / 2, scaleTexture(button_lvlUnlocked.pixelInset.y, Screen.height / 2),  272 * 1.5f * saveScaleFactorX, 206 * 1.5f * saveScaleFactorX);

				lvlSelectEmpty.pixelInset 		= new Rect(Screen.width / 2 - lvlSelectEmpty.pixelInset.width / 2, scaleTexture(lvlSelectEmpty.pixelInset.y, Screen.height / 3f),  272 * 1.5f * saveScaleFactorX, 206 * 1.5f * saveScaleFactorX);
				break;
			case 2:
				screen_Credits.pixelInset 		= new Rect(0, 0, scaleTexture(screen_Credits.pixelInset.width, Screen.width), Screen.height);
				break;
			case 3:
				screen_Tutorial.pixelInset 		= new Rect(0, 0, scaleTexture(screen_Tutorial.pixelInset.width, Screen.width), scaleTexture(screen_Tutorial.pixelInset.height, Screen.height));
				break;
		}
       

    }
    /// <summary>
    /// Scales the texture.
    /// </summary>
    /// <returns>The new texture size for smooth animation size.</returns>
    /// <param name="In">current size in</param>
    /// <param name="Out">preffered size out</param>
    private float scaleTexture(float In, float Out)
    {
        if (In > Out / 2)
        {
            In = In + (Out - In) / 6f;
        }
        else if (In < Out + 5f)
        {
            In = In + (Out - In) / 10f;
        }
        return In;
    }
    /// <summary>
    /// Get scale factor X based on base width (1920)
    /// </summary>
    /// <returns>The scale factor x.</returns>
    private float getScaleFactorX()
    { 
		return (float)Screen.width / calcSizesWidth;
	}
	/// <summary>
    /// Get Scale factor Y based on base height (1080)
    /// </summary>
    /// <returns>The scale factor y.</returns>
    private float getScaleFactorY()
    {
		return (float)Screen.height / calcSizesHeight;
	}
	/// <summary>
	/// Checks if button is pressed
	/// </summary>
	/// <returns><c>true</c>, if button was hit, <c>false</c> otherwise returns false.</returns>
	/// <param name="guiTexture">GUI texture of button</param>
	private bool HitTest(GUITexture guiTexture)
	{
		return (guiTexture.HitTest(Input.mousePosition) && Input.GetMouseButtonDown(0));
	}

}
