using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*  ============ Loading up Score Room =============
 *  This is the main start-up script for the Score Room. 
 *  The steps that occur are as follows: 
 *      1. All needed GameObjects are located and assigned to their appropriate variables.
 *      2. The player's points & strikes are displayed on the ScoreUI.
 *      3. If the Supply Room has not been completed successfully, the player will be unable to proceed to next level.
 *  
 *  ~Written by Austin Winkler
 *  ====================================== */

public class ScoreRoom_Load : MonoBehaviour
{
    private GameObject gameManager;
    private PlayerData PD;

    private Text strikes;
    private Text points;

    private GameObject nextLevel;

    public void Awake() // #1
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        PD = gameManager.GetComponent<PlayerData>();

        strikes = GameObject.FindGameObjectWithTag("ScoreUI_Mistakes").GetComponent<Text>();
        points = GameObject.FindGameObjectWithTag("ScoreUI_Points").GetComponent<Text>();

        nextLevel = GameObject.FindGameObjectWithTag("ScoreRoom_nextLevel");
    }

    public void Start()
    {
        strikes.text = PD.playerStrikes.ToString(); // #2
        points.text = PD.playerPoints.ToString();   // #2

        if (!PD.supplyRoom_Completion) // #3
        {
            nextLevel.SetActive(false);
        }
    }
}