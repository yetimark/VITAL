using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  ============ Loading up Supply Room =============
 *  This is the main start-up script for the Supply Room. 
 *  The steps that occur are as follows: 
 *      1. All needed GameObjects are located and assigned to their appropriate variables.
 *      2. The currLevel and nextLevel are set. This is important for when the player moves into the Score Room 
 *         (after completing or committing too many mistakes).
 *      3. The selected difficulty's values are assigned.
 *  
 *  ~Written by Austin Winkler
 *  ================================================= */

public class SupplyRoom_Load : MonoBehaviour
{
    private GameObject gameManager;
    private PlayerData PD;

    private GameObject player;
    private GameObject playerSpawnpoint;
    private GameObject timer;
    private Timer timerObject; // Throwaway instance of a Timer

    private GameObject easyMusic;
    private GameObject mediumMusic;
    private GameObject hardMusic;

    public void Awake() // #1
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        playerSpawnpoint = GameObject.Find("Spawnpoint");
        timer = GameObject.FindGameObjectWithTag("Timer");
        player = GameObject.FindGameObjectWithTag("Player");

        // Where music is located within the scene
        easyMusic = GameObject.FindGameObjectWithTag("EasyMusic");
        mediumMusic = GameObject.FindGameObjectWithTag("MediumMusic");
        hardMusic = GameObject.FindGameObjectWithTag("HardMusic");
    }

    public void Start()
    {
        timerObject = timer.GetComponent<Timer>();
        PD = gameManager.GetComponent<PlayerData>();

        PD.currLevel = "SupplyRoom"; // #3 - The level that the player is currently loading into
        PD.nextLevel = "MedRoom";    // #3 - The level that will come after the current level

        if (PD.difficulty == "Hard") // #4
        {
            hardMusic.GetComponent<AudioSource>().Play();
            StartCoroutine(timerObject.CountdownStart(timerObject.minutes = 1,
                                                      timerObject.seconds = 0,
                                                      timerObject.difficulty = "Hard"));
            PD.maxStrikes = 2;
        }
        else if (PD.difficulty == "Medium") // #4
        {
            mediumMusic.GetComponent<AudioSource>().Play();
            StartCoroutine(timerObject.CountdownStart(timerObject.minutes = 1,
                                                      timerObject.seconds = 30,
                                                      timerObject.difficulty = "Medium"));
            PD.maxStrikes = 4;
        }
        else // #4 - Easy is the default difficulty
        {
            easyMusic.GetComponent<AudioSource>().Play();
            StartCoroutine(timerObject.CountdownStart(timerObject.minutes = 3,
                                                      timerObject.seconds = 0,
                                                      timerObject.difficulty = "Easy"));
        }
    }
}
