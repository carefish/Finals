using UnityEngine;
using System.Collections;
using System;
using System.Reflection;
/// <summary>
/// This component is responsible for loading and instantiating objects needed for the game.
/// <param name="player">The prefab/GameObject controlled by the player</param>
/// <param name="level">The switchable level, switchable by setting 'levelName'</param>
/// <param name="playingFieldVolume">The box collider to aid in 'respawning' the player by setting the proper</param>
/// </summary>
public class InstantiateGame : MonoBehaviour
{
    public GameObject gameConfigObject;
    GameConfig gameConfig;
    GameObject player;
    GameObject level;
    GameObject playingFieldVolume;
    Transform playerSpawnPoint;
    string levelName = "";

    void Awake()
    {
        if (gameConfigObject == null)
        {
            Debug.LogWarning("GameConfig GameObject reference not set! Check the Camera's InstantiateGame script inspector");
        }
        gameConfig = gameConfigObject.GetComponent<GameConfig>();
        levelName = gameConfig.levelName;
    }

    void Start()
    {
        try
        {
            if (Resources.Load<GameObject>("Levels/" + levelName) == null)
            {
                throw new System.Exception("No valid level name! Please be sure to type a valid one!");
            }
            level = Instantiate(Resources.Load<GameObject>("Levels/" + levelName)) as GameObject;

            if (GameObject.Find("SpawnPoint") == null)
            {
                throw new System.Exception("No SpawnPoint in level! Please be sure to add a Game Object named \'SpawnPoint\'!");
            }
            playerSpawnPoint = level.GetComponent<SpawnPoint>().spawnPoint;

        }
        catch (System.Exception e)
        {
            Debug.LogException(e, this);
        }
        player = Instantiate(Resources.Load<GameObject>("player/obj_Player"), playerSpawnPoint.position, Quaternion.identity) as GameObject;
        GetComponent<FollowPlayer>().playerObject = player;
        //playingFieldVolume = Instantiate(Resources.Load<GameObject>("LevelParts/obj_PlayingFieldVolume")) as GameObject;//DEPRECATED, leave here for now.
    }

}
