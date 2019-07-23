using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*  ============= NextLevel =============
 *  This script allows the player to move from the Score Room to the next one.
 *  The Score Room's job is to act as a middle-man between skills. 
 *      1. All needed Objects are located and assigned to their appropriate variables.
 *      2. When the player interacts with the chalk on the blackboard tray, the player will procede to the next level
 *         If the player has not successfully completed the previous level/room, they will 
 *  
 *  ~Written by Austin Winkler
 *  ===================================== */

public class NextLevel : MonoBehaviour
{
    private GameObject gameManager;
    private PlayerData PD;

    private bool triggerCheck;

    public void Awake() // #1
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        PD = gameManager.GetComponent<PlayerData>();
    }

    public void OnTriggerEnter(Collider other) // #2
    {
        if (other.tag == "Player")
        {
            if (PD.supplyRoom_Completion)
            {
                SceneManager.LoadScene("" + PD.nextLevel);
            }
            // Medroom and all future rooms will need to have if-else cases to check their corresponding completion status
            else
            {
                Debug.Log("You must successfully complete the previous room before continuing!");
            }
        }
    }
}
