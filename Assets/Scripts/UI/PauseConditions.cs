using UnityEngine;
using System.Collections;

public class PauseConditions : MonoBehaviour
{
	// UI Buttons:
	public GameObject button1;
	public GameObject button2;
	public GameObject button3;
	public GameObject button4;

	// Pause Button
	GameObject pauseTxt1;
	GameObject pauseTxt2;
	float highScoreX;



    void Start()
    {

    }
    void Update()
    {

        

#if UNITY_ANDROID
		// Pause game if less or more than 4 fingers (2 players)
		if (inputPos(button1) && inputPos(button2) &&
           inputPos(button3) && inputPos(button4))
        {
            Time.timeScale = 1.0f;
			if(GameObject.Find(pauseTxt1.name))	{
				Destroy(GameObject.Find(pauseTxt1.name));
				Destroy(GameObject.Find(pauseTxt2.name));
			}
			
		}
		else if(Input.touchCount != 4)
        {
			showPauseText();

            Time.timeScale = 0.0f;
        }
#endif
    }
	/// <summary>
	/// Checks if Touch Input touches given Gameobject
	/// </summary>
	/// <returns><c>true</c>if finger touches gameobject <c>false</c> otherwise false</returns>
	/// <param name="checkPos">Check position.</param>
    private bool inputPos(GameObject checkPos)
    {
        foreach (Touch t in Input.touches)
        {
			if(checkPos.GetComponent<GUITexture>().pixelInset.width < 0 || 
			   checkPos.GetComponent<GUITexture>().pixelInset.height < 0)	{
				//Debug.Log("this has been found true!");
				if(t.position.x > checkPos.GetComponent<GUITexture>().pixelInset.x  + checkPos.GetComponent<GUITexture>().pixelInset.width &&
				   t.position.x < checkPos.GetComponent<GUITexture>().pixelInset.x &&
				   t.position.y > checkPos.GetComponent<GUITexture>().pixelInset.y + checkPos.GetComponent<GUITexture>().pixelInset.height && 
				   t.position.y < checkPos.GetComponent<GUITexture>().pixelInset.y )	{
					return true;
				}
				
			}
			else {
				if(checkPos.GetComponent<GUITexture>().HitTest(t.position))	{

					return true;
				}
			}
        }
        return false;
    }
	/// <summary>
	/// Displays Pause Text on screen
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
            Debug.LogException(ex, this);
            //pauseTxt1 = Instantiate(Resources.Load(loadThisResourceText)) as GameObject;
            //pauseTxt1.name = pauseTxt1.GetComponentInChildren<TextMesh>().text + 1;
            //pauseTxt2 = Instantiate(Resources.Load(loadThisResourceText)) as GameObject;
            //pauseTxt2.name = pauseTxt2.GetComponentInChildren<TextMesh>().text + 2;
		}
		
		
	}
}