using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {
    Timer newTime = new Timer(); //Timer Object deals with time and music
    public GameObject player;
    public GameObject spawn;

    public void Awake()
    {
        GameObject.Find("lobbyMusic").GetComponent<AudioSource>().Play();
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
    }
    public void MediumButton()
    {
        GameObject.Find("lobbyMusic").GetComponent<AudioSource>().Stop();
        new WaitForSeconds(0.5f);

        newTime.minutes = 1;
        newTime.seconds = 30;
        newTime.difficulty = "medium";

        this.player.transform.position = this.spawn.transform.position;
    }
    public void HardButton()
    {
        GameObject.Find("lobbyMusic").GetComponent<AudioSource>().Stop();
        new WaitForSeconds(0.5f);

        newTime.minutes = 1;
        newTime.seconds = 0;
        newTime.difficulty = "hard";

        this.player.transform.position = this.spawn.transform.position;
    }
}
