using UnityEngine;
using System.Collections;
/// <summary>
/// !--DEPRECATED CLASS--!
/// This component manages the level selection screen
/// It allows the player to select a level and play it if it's unlocked.
/// </summary>
public class UILevelSelect : MonoBehaviour
{
    // Public:
    public GUIStyle buttonStyle; 			// The Button Texture options
    public int levelAmount = 10;	// Howmany levels there are
    public int columnAmount = 3;	// columns per row
    public int paddingX = 100; 	// Padding width between buttons
    public int paddingY = 100; 	// Padding height between buttons
    public int buttonWidth = 100; 	// Width of button
    public int buttonHeight = 50; 	// Height of button
    public int startingPosHeight = 100; 	// Height of first button (offset height)
    public float setSize = 1;			// set Scale of Button for resolution independent buttons
    public const int calcSizesWidth = 1280;	// testdevice width Size taken
    public const int calcSizesHeight = 720;	// testdevice height Size taken

    // Private:
    private int saveCurrentWidth;
    private int saveCurrentHeight;
    private float saveButtonSizeX;
    private float saveButtonSizeY;
    private int amountOfRows;
    private float buttonSizeX;
    private float buttonSizeY;

    // Rotate GUI
    private float rotAngle = 0;
    private Vector2 pivotPoint;
    // Use this for initialization
    void Start()
    {
        saveCurrentWidth = Screen.width;
        saveCurrentHeight = Screen.height;
        saveButtonSizeX = (float)getGuiScale(1, buttonWidth, 100).x;
        amountOfRows = (int)Mathf.Ceil(levelAmount / columnAmount);
        saveButtonSizeY = (float)getGuiScale(1, 100, buttonHeight).y;
        buttonSizeX = saveButtonSizeX;
        buttonSizeY = saveButtonSizeY;
    }

    // Update is called once per frame
    void Update()
    {
        updateButtonSize();
    }

    void OnGUI()
    {
        positionlevelSelect((int)getGuiScale(1, paddingX, 100).x, (int)getGuiScale(1, paddingY, paddingY).y);
    }
    /// <summary>
    /// Position and create Buttons
    /// </summary>
    /// <param name="paddingX">Padding x, padding width (width between each button)</param>
    /// <param name="paddingY">Padding y, padding height (height between each button)</param>
    void positionlevelSelect(int paddingX, int paddingY)
    {

        //Debug.Log("amountOfRows:" + amountOfRows);
        int CenterPoint = (int)((Screen.width / 2) - (((buttonSizeX) * (columnAmount) + (paddingX * (columnAmount - 1))) / 2));
        for (int i = 0; i < amountOfRows; i++)
        {
            for (int j = 0; j < columnAmount; ++j)
            {

                pivotPoint = new Vector2(Screen.width / 2, Screen.height / 2);
                GUIUtility.RotateAroundPivot(rotAngle, pivotPoint);
                if (GUI.Button(new Rect((j * (buttonSizeX + paddingX) + CenterPoint), i * (buttonSizeY + paddingY) + (float)getGuiScale(1, 100, startingPosHeight).y, saveButtonSizeX, saveButtonSizeY), "Level " + (1 + j + columnAmount * i), buttonStyle))
                {

                    Application.LoadLevel("Level" + (j + columnAmount * i).ToString());
                }
            }
        }
    }
    /// <summary>
    /// Get Scale of GUI for different resolutions based on 1280 * 720
    /// </summary>
    /// <returns>The new resolution GUI scale.</returns>
    /// <param name="scaleFactorUnknown">Scale factor of Button (easy scaling incode)</param>
    /// <param name="baseSizeWidth">Base size width.</param>
    /// <param name="baseSizeHeight">Base size height.</param>
    Vector2 getGuiScale(int scaleFactorUnknown, int baseSizeWidth, int baseSizeHeight)
    {
        int baseSizex = baseSizeWidth;
        int baseSizey = baseSizeHeight;
        float scaleFactorX = getScaleFactorX();
        float scaleFactorY = getScaleFactorY();
        Vector2 returnNewScale = new Vector2(baseSizex * scaleFactorX * setSize, baseSizey * scaleFactorY * setSize);

        //Debug.Log(scaleFactor);
        return returnNewScale;
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
    private void updateButtonSize()
    {
        amountOfRows = (int)Mathf.Ceil(levelAmount / columnAmount);
        if (saveCurrentWidth != Screen.width || saveCurrentHeight != Screen.height)
        {

            saveButtonSizeX = (float)getGuiScale(1, buttonWidth, 100).x;
            saveButtonSizeY = (float)getGuiScale(1, 100, buttonHeight).y;
            buttonSizeX = saveButtonSizeX;
            buttonSizeY = saveButtonSizeY;
            saveCurrentWidth = Screen.width;
            saveCurrentHeight = Screen.height;
        }
    }
}
