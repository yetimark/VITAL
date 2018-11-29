using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {
    Timer newTime = new Timer(); //Timer Object deals with time and music
    public GameObject player;
    public GameObject spawn;
    private GameObject gameUI;

    public void Awake()
    {
        Debug.Log("lobbyMusic");
        GameObject.Find("lobbyMusic").GetComponent<AudioSource>().Play();
        this.gameUI = GameObject.Find("Game UI");
    }

    public void EasyButton()
    {
        GameObject.Find("lobbyMusic").GetComponent<AudioSource>().Stop();
        new WaitForSeconds(0.5f);

        GameObject.Find("easyMusic").GetComponent<AudioSource>().Play();

        newTime.minutes = 3;
        newTime.seconds = 0;
        newTime.difficulty = "easy";
        //newTime.soundOn = true;

        this.player.transform.position = this.spawn.transform.position;
        this.player.transform.rotation = spawn.transform.rotation;

        //set to number of max strikes
        //   this.gameUI.GetComponent<UIGame>().strikeMax = -1;

        //infinite for novice?
        GameObject.Find("StrikePanel");
    }
    public void MediumButton()
    {
        GameObject.Find("lobbyMusic").GetComponent<AudioSource>().Stop();
        new WaitForSeconds(0.5f);

        newTime.minutes = 1;
        newTime.seconds = 30;
        newTime.difficulty = "medium";
        //newTime.soundOn = true;
        
        GameObject.Find("mediumMusic").GetComponent<AudioSource>().Play();

        this.player.transform.position = this.spawn.transform.position;
        this.player.transform.rotation = spawn.transform.rotation;

        this.gameUI.GetComponent<UIGame>().strikeMax = 4;
    }
    public void HardButton()
    {
        GameObject.Find("lobbyMusic").GetComponent<AudioSource>().Stop();
        new WaitForSeconds(0.5f);

        newTime.minutes = 1;
        newTime.seconds = 0;
        newTime.difficulty = "hard";
        //newTime.soundOn = true;

        GameObject.Find("hardMusic").GetComponent<AudioSource>().Play();
        
        this.player.transform.position = this.spawn.transform.position;
        this.player.transform.rotation = spawn.transform.rotation;

        this.gameUI.GetComponent<UIGame>().strikeMax = 2;
    }
}
