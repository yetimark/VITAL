using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyButtons : MonoBehaviour
{
    public GameObject player;
    public GameObject spawn;
    private GameObject gameUI;
    private GameObject timer;

    public void Awake()
    {
        Debug.Log("lobbyMusic");
        GameObject.Find("lobbyMusic").GetComponent<AudioSource>().Play();
        this.gameUI = GameObject.Find("Game UI");
        this.timer = GameObject.Find("Timer");
    }

    public void EasyButton()
    {
        GameObject.Find("lobbyMusic").GetComponent<AudioSource>().Stop();
        new WaitForSeconds(0.5f);

        Debug.Log("EasyButton pressed");
        StartCoroutine(timer.GetComponent<Timer>().CountdownStart(timer.GetComponent<Timer>().minutes = 3,
                                                                  timer.GetComponent<Timer>().seconds = 0,
                                                                  timer.GetComponent<Timer>().difficulty = "easy"));

        this.player.transform.position = this.spawn.transform.position;
        this.player.transform.rotation = this.spawn.transform.rotation;
        GameObject.Find("StrikePanel");
    }
    public void MediumButton()
    {
        GameObject.Find("lobbyMusic").GetComponent<AudioSource>().Stop();
        new WaitForSeconds(0.5f);

        Debug.Log("MediumButton pressed");
        
        GameObject.Find("mediumMusic").GetComponent<AudioSource>().Play();

        this.player.transform.position = this.spawn.transform.position;
        this.player.transform.rotation = this.spawn.transform.rotation;
        StartCoroutine(timer.GetComponent<Timer>().CountdownStart(timer.GetComponent<Timer>().minutes = 1,
                                                                  timer.GetComponent<Timer>().seconds = 30,
                                                                  timer.GetComponent<Timer>().difficulty = "medium"));

        this.gameUI.GetComponent<UIGame>().strikeMax = 4;
    }
    public void HardButton()
    {
        GameObject.Find("lobbyMusic").GetComponent<AudioSource>().Stop();
        new WaitForSeconds(0.5f);

        Debug.Log("HardButton pressed");

        GameObject.Find("hardMusic").GetComponent<AudioSource>().Play();

        this.player.transform.position = this.spawn.transform.position;
        this.player.transform.rotation = this.spawn.transform.rotation;

        StartCoroutine(timer.GetComponent<Timer>().CountdownStart(timer.GetComponent<Timer>().minutes = 1,
                                                                  timer.GetComponent<Timer>().seconds = 0,
                                                                  timer.GetComponent<Timer>().difficulty = "hard"));

        this.gameUI.GetComponent<UIGame>().strikeMax = 2;
    }
}
