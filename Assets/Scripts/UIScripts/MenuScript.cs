using UnityEngine;
using System.Collections;
/// <summary>
/// This component is responsible for the menu's in the game.
/// This component is also the entry point for many of the User Interface elements
/// </summary>
public class MenuScript : MonoBehaviour
{
    // All assets (gameobjects) needed for main menu:
    private GameObject button_Credits;
    private GameObject Screen_Credits;

    private GameObject button_LvlSelect;
    private GameObject Screen_LvlSelect;
    private GameObject Screen_Menu;
    private GameObject button_lvlUnlocked;

    private GameObject button_Tutorial;
    private GameObject Screen_Tutorial;
    private GameObject lvlSelectEmpty;
    private GameObject lvlSelectNotCompleted;
    /// <summary>
    /// Which Screen is currently visible to the user (tutorial, menu or credits)
    /// </summary>
    private int switchScreens = 0;

    // These are Full HD because quickly tested on GS4 (1920 x 1080 display)
    public const int calcSizesWidth = 1080;	// testdevice width Size taken
    public const int calcSizesHeight = 1920;	// testdevice height Size taken
    void Start()
    {
        //-------- Setup gameobjects to variables: --------\\
        button_Credits = GameObject.Find("btn_credit_up");
        Screen_Credits = GameObject.Find("Menu_CreditScreen");
        button_LvlSelect = GameObject.Find("btn_play_up");
        Screen_LvlSelect = GameObject.Find("Menu_LvlSelect");
        button_Tutorial = GameObject.Find("btn_tutorial_up");
        Screen_Tutorial = GameObject.Find("Menu_tutorial_bg");
        button_lvlUnlocked = GameObject.Find("level_unlock");
        Screen_Menu = GameObject.Find("Menu_start_bg");
        lvlSelectEmpty = GameObject.Find("level_empty");

        //---------------- End of Setup ----------------\\
        Screen_Menu.GetComponent<GUITexture>().pixelInset = new Rect(0, 0, Screen.width, Screen.height);

        button_Credits.GetComponent<GUITexture>().pixelInset = new Rect(100 * getScaleFactorX(), 1100 * getScaleFactorY(),
                                                                        272 * getScaleFactorX(), 272 * getScaleFactorX());
        button_LvlSelect.GetComponent<GUITexture>().pixelInset = new Rect(400 * getScaleFactorX(), 1100 * getScaleFactorY(),
                                                                          272 * getScaleFactorX(), 272 * getScaleFactorX());
        button_Tutorial.GetComponent<GUITexture>().pixelInset = new Rect(700 * getScaleFactorX(), 1100 * getScaleFactorY(),
                                                                         272 * getScaleFactorX(), 272 * getScaleFactorX());
        button_lvlUnlocked.GetComponent<GUITexture>().pixelInset = new Rect(272 * getScaleFactorX(), -2000 * getScaleFactorY(),
                                                                            272 * getScaleFactorX(), 206 * getScaleFactorX());
        lvlSelectEmpty.GetComponent<GUITexture>().pixelInset = new Rect(272 * getScaleFactorX(), -2600 * getScaleFactorY(),
                                                                        272 * getScaleFactorX(), 206 * getScaleFactorX());

    }


    void Update()
    {
        // Reset screen to main menu when back button pressed on Android Phone:
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Screen_Menu.transform.position = new Vector3(0, 0, 1);
            Screen_LvlSelect.transform.position = new Vector3(0, 0, 0);
            Screen_Credits.transform.position = new Vector3(0, 0, 0);
            button_lvlUnlocked.transform.position = new Vector3(0, 0, 0);
            Screen_Tutorial.transform.position = new Vector3(0, 0, 0);

            Screen_Tutorial.GetComponent<GUITexture>().pixelInset = new Rect(0, 0, 0, 0);
            Screen_LvlSelect.GetComponent<GUITexture>().pixelInset = new Rect(0, 0, 0, 0);
            button_lvlUnlocked.GetComponent<GUITexture>().pixelInset = new Rect(Screen.width / 2 - button_lvlUnlocked.GetComponent<GUITexture>().pixelInset.width / 2, -2000, button_lvlUnlocked.GetComponent<GUITexture>().pixelInset.width, button_lvlUnlocked.GetComponent<GUITexture>().pixelInset.height);
            Screen_Credits.GetComponent<GUITexture>().pixelInset = new Rect(0, 0, 0, Screen.height);
            lvlSelectEmpty.GetComponent<GUITexture>().pixelInset = new Rect(272 * getScaleFactorX(), -2600 * getScaleFactorY(),
                                                                            272 * getScaleFactorX(), 206 * getScaleFactorX());
            switchScreens = 0;
            //Application.Quit();

        }

        // Goto Credit screen:
        if (button_Credits.GetComponent<GUITexture>().HitTest(Input.mousePosition) && Input.GetMouseButtonDown(0))
        {
            Screen_Credits.transform.position = new Vector3(0, 0, 3);
            switchScreens = 2;
        }
        // Goto Level Select screen:
        if (button_LvlSelect.GetComponent<GUITexture>().HitTest(Input.mousePosition) && Input.GetMouseButtonDown(0))
        {
            Screen_LvlSelect.transform.position = new Vector3(0, 0, 3);
            button_lvlUnlocked.transform.position = new Vector3(0, 0, 4);
            lvlSelectEmpty.transform.position = new Vector3(0, 0, 4);
            switchScreens = 1;
        }
        // If Level Unlocked play this level (currently no other levels so no unlockable as of yet):
        if (button_lvlUnlocked.GetComponent<GUITexture>().HitTest(Input.mousePosition) && Input.GetMouseButtonDown(0))
        {
            // Application.loadlevel(?);
            Application.LoadLevel(2);
        }
        if (lvlSelectEmpty.GetComponent<GUITexture>().HitTest(Input.mousePosition) && Input.GetMouseButtonDown(0))
        {
            // Application.loadlevel(?);
            Application.LoadLevel(1);
        }
        // Goto Tutorial Screen if Pressed:
        if (button_Tutorial.GetComponent<GUITexture>().HitTest(Input.mousePosition) && Input.GetMouseButtonDown(0))
        {
            Screen_Tutorial.transform.position = new Vector3(0, 0, 3);
            switchScreens = 3;

        }
        // Checks which menu screen is currently active :
        if (switchScreens == 1)
        {

            Screen_LvlSelect.GetComponent<GUITexture>().pixelInset = new Rect(Screen.width - Screen_LvlSelect.GetComponent<GUITexture>().pixelInset.width, 0,
                                                                              scaleTexture(Screen_LvlSelect.GetComponent<GUITexture>().pixelInset.width, Screen.width),
                                                                              scaleTexture(Screen_LvlSelect.GetComponent<GUITexture>().pixelInset.height, Screen.height));
            button_lvlUnlocked.GetComponent<GUITexture>().pixelInset = new Rect(Screen.width / 2 - button_lvlUnlocked.GetComponent<GUITexture>().pixelInset.width / 2,
                                                                                scaleTexture(button_lvlUnlocked.GetComponent<GUITexture>().pixelInset.y, Screen.height / 2), 272 * 1.5f * getScaleFactorX(), 206 * 1.5f * getScaleFactorX());
            lvlSelectEmpty.GetComponent<GUITexture>().pixelInset = new Rect(Screen.width / 2 - lvlSelectEmpty.GetComponent<GUITexture>().pixelInset.width / 2,
                                                                                scaleTexture(lvlSelectEmpty.GetComponent<GUITexture>().pixelInset.y, Screen.height / 3f), 272 * 1.5f * getScaleFactorX(), 206 * 1.5f * getScaleFactorX());
        }
        else if (switchScreens == 2)
        {
            Screen_Credits.GetComponent<GUITexture>().pixelInset = new Rect(0, 0,
                                                                            scaleTexture(Screen_Credits.GetComponent<GUITexture>().pixelInset.width, Screen.width),
                                                                             Screen.height);
        }
        else if (switchScreens == 3)
        {

            Screen_Tutorial.GetComponent<GUITexture>().pixelInset = new Rect(0, 0,
                                                                              scaleTexture(Screen_Tutorial.GetComponent<GUITexture>().pixelInset.width, Screen.width),
                                                                              scaleTexture(Screen_Tutorial.GetComponent<GUITexture>().pixelInset.height, Screen.height));
        }
        // ------------------------------------------------------------

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
        float scaleFactorX = (float)Screen.width / calcSizesWidth;
        return scaleFactorX;
    }
    /// <summary>
    /// Get Scale factor Y based on base height (1080)
    /// </summary>
    /// <returns>The scale factor y.</returns>
    private float getScaleFactorY()
    {
        float scaleFactorY = (float)Screen.height / calcSizesHeight;
        return scaleFactorY;
    }
}
