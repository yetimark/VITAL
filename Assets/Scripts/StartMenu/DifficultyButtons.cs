using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyButtons : MonoBehaviour
{
    public GameObject player;
    public GameObject spawn;
    private GameObject gameUI;


    public void Awake()
    {
        Debug.Log("lobbyMusic");
        GameObject.Find("lobbyMusic").GetComponent<AudioSource>().Play();
        this.gameUI = GameObject.Find("Game UI");
    }

    public void Start()
    {

    }

    public void EasyButton()
    {
        GameObject.Find("lobbyMusic").GetComponent<AudioSource>().Stop();
        new WaitForSeconds(0.5f);

        Debug.Log("EasyButton");
        StartCoroutine(GameObject.Find("Timer").GetComponent<Timer>().CountdownStart(GameObject.Find("Timer").GetComponent<Timer>().minutes = 3,
                                                                                     GameObject.Find("Timer").GetComponent<Timer>().seconds = 0,
                                                                                     GameObject.Find("Timer").GetComponent<Timer>().difficulty = "easy"));

        this.player.transform.position = this.spawn.transform.position;
        this.player.transform.rotation = spawn.transform.rotation;
        GameObject.Find("StrikePanel");
    }
    public void MediumButton()
    {
        GameObject.Find("lobbyMusic").GetComponent<AudioSource>().Stop();
        new WaitForSeconds(0.5f);

        Debug.Log("MediumButton");
        
        GameObject.Find("mediumMusic").GetComponent<AudioSource>().Play();

        this.player.transform.position = this.spawn.transform.position;
        this.player.transform.rotation = spawn.transform.rotation;
        StartCoroutine(GameObject.Find("Timer").GetComponent<Timer>().CountdownStart(GameObject.Find("Timer").GetComponent<Timer>().minutes = 1, 
                                                                                     GameObject.Find("Timer").GetComponent<Timer>().seconds = 30, 
                                                                                     GameObject.Find("Timer").GetComponent<Timer>().difficulty = "medium"));

        this.gameUI.GetComponent<UIGame>().strikeMax = 4;
    }
    public void HardButton()
    {
            GameObject.Find("lobbyMusic").GetComponent<AudioSource>().Stop();
            new WaitForSeconds(0.5f);

            Debug.Log("HardButton");
        StartCoroutine(GameObject.Find("Timer").GetComponent<Timer>().CountdownStart(GameObject.Find("Timer").GetComponent<Timer>().minutes = 1,
                                                                                     GameObject.Find("Timer").GetComponent<Timer>().seconds = 0,
                                                                                     GameObject.Find("Timer").GetComponent<Timer>().difficulty = "hard"));
        GameObject.Find("hardMusic").GetComponent<AudioSource>().Play();

        this.player.transform.position = this.spawn.transform.position;
        this.player.transform.rotation = spawn.transform.rotation;

        this.gameUI.GetComponent<UIGame>().strikeMax = 2;
    }
}
