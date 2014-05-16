using UnityEngine;
using System.Collections;
/// <summary>
/// Configuration for the game.
/// For use with GetComponent<>();
/// Controlled in the editor by GameConfigHelper
/// </summary>
public class GameConfig : MonoBehaviour
{
    public string levelName = "Level01";
    public float playerSpeed = 1.61803f;
}
