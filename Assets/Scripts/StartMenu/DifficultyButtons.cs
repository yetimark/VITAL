using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyButtons : MonoBehaviour
{
    Timer newTime = new Timer(); 
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

        Debug.Log("EasyMusicButtons");
        newTime.minutes = 3;
        newTime.seconds = 0;
        newTime.difficulty = "easy";

        this.player.transform.position = this.spawn.transform.position;
        this.player.transform.rotation = spawn.transform.rotation;
        GameObject.Find("StrikePanel");
    }
    public void MediumButton()
    {
        GameObject.Find("lobbyMusic").GetComponent<AudioSource>().Stop();
        new WaitForSeconds(0.5f);

        newTime.minutes = 1;
        newTime.seconds = 30;
        newTime.difficulty = "medium";

        GameObject.Find("mediumMusic").GetComponent<AudioSource>().Play();

        this.player.transform.position = this.spawn.transform.position;
        this.player.transform.rotation = spawn.transform.rotation;
        //StartCoroutine(GameObject.Find("Timer").GetComponent<Timer>().CountdownStart(1, 30));

        this.gameUI.GetComponent<UIGame>().strikeMax = 4;
    }
    public void HardButton()
    //public void OnTriggerEnter(Collider other)
    {
        //if (other == GameObject.FindGameObjectWithTag("Player"))
        //{
            GameObject.Find("lobbyMusic").GetComponent<AudioSource>().Stop();
            new WaitForSeconds(0.5f);

            newTime.minutes = 1;
            newTime.seconds = 0;
            newTime.difficulty = "hard";
            //newTime.soundOn = true;

            GameObject.Find("hardMusic").GetComponent<AudioSource>().Play();

            this.player.transform.position = this.spawn.transform.position;
            this.player.transform.rotation = spawn.transform.rotation;
            //StartCoroutine(GameObject.Find("Timer").GetComponent<Timer>().CountdownStart(1, 0));

            this.gameUI.GetComponent<UIGame>().strikeMax = 2;
        //}
    }
}
