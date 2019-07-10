using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyRoom : MonoBehaviour
{
    private GameObject gameManager;
    private PlayerData PD;

    private GameObject player;
    private GameObject playerSpawnpoint;
    private GameObject timer;

    private GameObject easyMusic;
    private GameObject mediumMusic;
    private GameObject hardMusic;

    public void Awake()
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
        Timer timerObject = timer.GetComponent<Timer>();
        PD = gameManager.GetComponent<PlayerData>();
        PD.Load();

        // Teleports player to center of room
        player.transform.position = playerSpawnpoint.transform.position;

        if (PD.difficulty == "Hard")
        {
            hardMusic.GetComponent<AudioSource>().Play();
            StartCoroutine(timerObject.CountdownStart(timerObject.minutes = 1,
                                                      timerObject.seconds = 0,
                                                      timerObject.difficulty = "Hard"));
            PD.maxStrikes = 2;
        }
        else if (PD.difficulty == "Medium")
        {
            mediumMusic.GetComponent<AudioSource>().Play();
            StartCoroutine(timerObject.CountdownStart(timerObject.minutes = 1,
                                                      timerObject.seconds = 30,
                                                      timerObject.difficulty = "Medium"));
            PD.maxStrikes = 4;
        }
        else //The default is Easy Difficulty
        {
            easyMusic.GetComponent<AudioSource>().Play();
            StartCoroutine(timerObject.CountdownStart(timerObject.minutes = 3,
                                                      timerObject.seconds = 0,
                                                      timerObject.difficulty = "Easy"));
        }
    }
    
}
