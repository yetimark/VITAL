using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  ============= NextLevel =============
 *  This script allows the player to move from the Score Room to the next one.
 *  The Score Room's job is to act as a middle-man between skills. 
 *      1. All needed Objects are located and assigned to their appropriate variables.
 *      2. Loads PlayerData 
 *  
 *  UPDATE: Originally this was designed for use between scenes. After I realized this was not needed, this script will be solely used for resuming a game which has been quit (LATE game addition)
 *  ~Written by Austin Winkler
 *  ===================================== */

public class LoadData : MonoBehaviour
{
    private GameObject gameManager;
    private PlayerData PD;

    private GameObject player;

    public void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        PD = gameManager.GetComponent<PlayerData>();
        //PD.Load();

        player = GameObject.FindGameObjectWithTag("Player");
    }
}
