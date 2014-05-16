using UnityEngine;
using System.Collections;

public class HighScoreGUI : MonoBehaviour
{
    GameObject highScore1;
    GameObject highScore2;
    // Position centered:
    float highScoreX;
    float scorePoints;
    void Start()
    {
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
        scorePoints += Time.deltaTime;
        highScore1.GetComponent<TextMesh>().text = "Score:" + ((int)scorePoints).ToString();
        highScore2.GetComponent<TextMesh>().text = "Score:" + ((int)scorePoints).ToString();
        highScoreX = (highScore1.renderer.bounds.size.x / 2);
        highScore1.transform.position = new Vector3(this.transform.position.x - highScoreX, this.transform.position.y - 0.18f, this.transform.position.z + 0.35f);
        highScore2.transform.position = new Vector3(this.transform.position.x + highScoreX, this.transform.position.y + 0.18f, this.transform.position.z + 0.35f);
    }
}
