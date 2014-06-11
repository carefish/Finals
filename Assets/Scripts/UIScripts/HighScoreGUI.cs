using UnityEngine;
using System.Collections;
/// <summary>
/// !--DEPRECATED CLASS--!
/// This component manages the score to be displayed properly in the game.
/// It retrieves a playerObject via GetComponent<>();
/// It also updates the ScoreCounter with the new score.
/// </summary>
public class HighScoreGUI : MonoBehaviour
{
    GameObject playerReference;
    public int totalPoints;
    GameObject highScore1;
    GameObject highScore2;
    // Position centered:
    float highScoreX;
    void Start()
    {
        playerReference = GetComponent<FollowPlayer>().playerObject;
        highScore1 = Instantiate(Resources.Load("LevelParts/ui_HighScore")) as GameObject;
        highScore1.name = "HighScore1";
        highScore2 = Instantiate(Resources.Load("LevelParts/ui_HighScore")) as GameObject;
        highScore2.name = "HighScore2";
        highScoreX = (highScore1.renderer.bounds.size.x / 2);
        highScore1.transform.localScale = new Vector3(0.01f, 0.01f, 0.2f);
        highScore2.transform.localScale = new Vector3(0.01f, 0.01f, 0.2f);
        highScore2.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
    }
    
    void Update()
    {
        totalPoints = playerReference.GetComponent<ScoreCounter>().totalPoints;
        highScore1.GetComponent<TextMesh>().text = "Score:" + totalPoints.ToString();
        highScore2.GetComponent<TextMesh>().text = "Score:" + totalPoints.ToString();
        highScoreX = (highScore1.renderer.bounds.size.x / 2);
        highScore1.transform.position = new Vector3(this.transform.position.x - highScoreX, this.transform.position.y - 0.18f, this.transform.position.z + 0.35f);
        highScore2.transform.position = new Vector3(this.transform.position.x + highScoreX, this.transform.position.y + 0.18f, this.transform.position.z + 0.35f);
    }
}
