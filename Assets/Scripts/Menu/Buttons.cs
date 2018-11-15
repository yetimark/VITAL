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
        GameObject.Find("lobbyMusic").GetComponent<AudioSource>().Play();
        this.gameUI = GameObject.Find("Game UI");
    }

    public void EasyButton()
    {
        GameObject.Find("lobbyMusic").GetComponent<AudioSource>().Stop();
        new WaitForSeconds(0.5f);

        newTime.minutes = 3;
        newTime.seconds = 0;
        newTime.difficulty = "easy";

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

        this.player.transform.position = this.spawn.transform.position;

        this.gameUI.GetComponent<UIGame>().strikeMax = 4;
    }
    public void HardButton()
    {
        GameObject.Find("lobbyMusic").GetComponent<AudioSource>().Stop();
        new WaitForSeconds(0.5f);

        newTime.minutes = 1;
        newTime.seconds = 0;
        newTime.difficulty = "hard";

        this.player.transform.position = this.spawn.transform.position;

        this.gameUI.GetComponent<UIGame>().strikeMax = 1;
    }
}
