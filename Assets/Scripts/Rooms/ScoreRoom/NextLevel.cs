using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*  ============= Score Room =============
 *  This script allows the player to move from their previous room to the next one.
 *  The Score Room's job is to act as a middle-man between skills. 
 *      1. 
 *  
 *  ~Written by Austin Winkler
 *  ====================================== */

public class NextLevel : MonoBehaviour
{
    private GameObject gameManager;
    private PlayerData PD;

    public void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        PD = gameManager.GetComponent<PlayerData>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("" + PD.nextLevel);
        }
    }
}
