using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyRoom : MonoBehaviour
{
    private GameObject gameManager;

    private GameObject timer;
    private GameObject easyMusic;
    private GameObject mediumMusic;
    private GameObject hardMusic;

    public void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        timer = GameObject.Find("Timer");

        //Where music is located within the scene
        easyMusic = GameObject.FindGameObjectWithTag("EasyMusic");
        mediumMusic = GameObject.FindGameObjectWithTag("MediumMusic");
        hardMusic = GameObject.FindGameObjectWithTag("HardMusic");

    }

    public void Start()
    {
        PlayerData PD = gameManager.GetComponent<PlayerData>();
        Timer timerObject = timer.GetComponent<Timer>();
        PD.Load();

        if (PD.difficulty == "Easy")
        {
            easyMusic.GetComponent<AudioSource>().Play();
            StartCoroutine(timerObject.CountdownStart(timerObject.minutes = 3,
                                                      timerObject.seconds = 0,
                                                      timerObject.difficulty = "Easy"));
        }
        else if (PD.difficulty == "Medium")
        {
            mediumMusic.GetComponent<AudioSource>().Play();
            StartCoroutine(timerObject.CountdownStart(timerObject.minutes = 1,
                                                      timerObject.seconds = 30,
                                                      timerObject.difficulty = "Medium"));
            PD.maxStrikes = 4;
        }
        else //The default is Hard Difficulty
        {
            hardMusic.GetComponent<AudioSource>().Play();

            StartCoroutine(timerObject.CountdownStart(timerObject.minutes = 1,
                                                      timerObject.seconds = 0,
                                                      timerObject.difficulty = "Hard"));
            PD.maxStrikes = 2;
        }
    }
    
}
