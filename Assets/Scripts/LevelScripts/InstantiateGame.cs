﻿using UnityEngine;
using System.Collections;
using System;
using System.Reflection;
/// <summary>
/// This component is responsible for loading and instantiating objects needed for the game.
/// <param name="player">The prefab/GameObject controlled by the player</param>
/// <param name="level">The switchable level, switchable by setting 'levelName'</param>
/// <param name="playingFieldVolume">The box collider to aid in 'respawning' the player by setting the proper position [DEPRECATED]</param>
/// <param name="gameConfig">Configuration for the game for inside Unity's Editor </param>
/// <param name="uiIngame">User Interface for the game</param>
/// <param name="playerSpawnPoint">The spawnpoint retreived from the game </param>
/// <param name="levelName">The level prefab to load per scene </param>
/// </summary>
public class InstantiateGame : MonoBehaviour
{
    public GameObject gameConfigObject;
    GameConfig gameConfig;
    GameObject player;
    GameObject level;
    GameObject playingFieldVolume;
	GameObject uiIngame;
	GUITexture button1;
	GUITexture button2;
	GUITexture button3;
	GUITexture button4;
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
        Application.targetFrameRate = 30;
    }

    void Start()
    {
        try
        {
			//uiIngame = Instantiate(Resources.Load<GameObject>("UI")) as GameObject;
			// check if instantiate is possible otherwise throw exception
#if UNITY_ANDROID
            if ((uiIngame = Instantiate(Resources.Load<GameObject>("UI")) as GameObject) == null)
            {
                throw new System.Exception("Failed to initialize User Interface!");
            }
            assignButtons();
#endif
			
            if (Resources.Load<GameObject>("Levels/" + levelName) == null)
            {
                throw new System.Exception("No valid level name! Please be sure to type a valid one!");
            }
            level = Instantiate(Resources.Load<GameObject>("Levels/" + levelName)) as GameObject;

            if (level.transform.FindChild("SpawnPoint") == null)
            {
                throw new System.Exception("No SpawnPoint in level! Please be sure to add a Game Object named \'SpawnPoint\'!");
            }

            playerSpawnPoint = level.GetComponent<SpawnPoint>().spawnPoint;
           

        }
        catch (System.Exception e)
        {
            Debug.LogException(e, this);
        }

        player = Instantiate(Resources.Load<GameObject>("Player/obj_Player"), playerSpawnPoint.position, Quaternion.identity) as GameObject;

        GetComponent<FollowPlayer>().playerObject = player;
        BlockTransparency[] blocks = level.GetComponentsInChildren<BlockTransparency>();//adding proximity-based transparency
        foreach (BlockTransparency block in blocks)
        {
            block.player = player;
        }

        WaterTransparency[] waterPlane = level.GetComponentsInChildren<WaterTransparency>();//adding proximity-based transparency
        foreach (WaterTransparency w in waterPlane)
        {
            w.player = player;
        }


        //playingFieldVolume = Instantiate(Resources.Load<GameObject>("LevelParts/obj_PlayingFieldVolume")) as GameObject;//DEPRECATED, leave here for now.
    }
	/// <summary>
	/// Assign buttons to pauseconditions Script
	/// </summary>
	private void assignButtons()	{

		// CODING EXAMPLE, DIFFERENT WAY TO DO THIS:
		//button1 = GameObject.Find("Button1");
		//GetComponent<PauseConditions>().button1 = button1;
		GetComponent<PauseConditions>().button1 = uiIngame.transform.FindChild("UI_p1").gameObject.transform.FindChild("Button1").gameObject.GetComponent<GUITexture>();
		GetComponent<PauseConditions>().button2 = uiIngame.transform.FindChild("UI_p1").gameObject.transform.FindChild("Button2").gameObject.GetComponent<GUITexture>();
		GetComponent<PauseConditions>().button3 = uiIngame.transform.FindChild("UI_p2").gameObject.transform.FindChild("Button3").gameObject.GetComponent<GUITexture>();
		GetComponent<PauseConditions>().button4 = uiIngame.transform.FindChild("UI_p2").gameObject.transform.FindChild("Button4").gameObject.GetComponent<GUITexture>();
	}

}
