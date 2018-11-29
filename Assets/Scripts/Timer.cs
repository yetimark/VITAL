using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int minutes = 0;
    public int seconds = -1;
    public string difficulty = "null";
    //private bool soundOn = false; //tells if music is currently playing
    private string convertedTime; //change this value before runtime
    private string display;
    public bool soundOn = false;


    void Start ()
    {
        StartCoroutine(CountdownStart(this.minutes, this.seconds));
    }

    void Update ()
    {
        GameObject.Find("ClockText").GetComponent<Text>().text = this.display;
	}

    public IEnumerator CountdownStart(float minutes, float seconds)
    {
        //if (this.soundOn == true)
        //{
            GameObject.Find("lobbyMusic").GetComponent<AudioSource>().Stop();
            //this.soundOn = false;
            Debug.Log("Lobby sound is off");
        //}

        while (this.seconds > -1)
        {
            if (this.seconds <= 9)
            {
                this.display = minutes + ":0" + seconds;
            }
            else
            {
                this.display = this.minutes + ":" + this.seconds;
            }

            if (this.minutes == 0 && this.seconds == 30)
            {
                //while (this.soundOn == true)
                //{
                if (this.difficulty == "easy")
                {
                    GameObject.Find("easyMusic").GetComponent<AudioSource>().Stop();
                    //this.soundOn = false;
                } //Stops easy music
                if (this.difficulty == "medium")
                {
                    GameObject.Find("mediumMusic").GetComponent<AudioSource>().Stop();
                    //this.soundOn = false;
                } //Stops medium music
                if (this.difficulty == "hard")
                {
                    GameObject.Find("hardMusic").GetComponent<AudioSource>().Stop();
                    //this.soundOn = false;
                } //Stops hard music
                  //starting HeartBeat
                GameObject.Find("HeartBeat").GetComponent<AudioSource>().Play();
                //}
            }
            else if (this.minutes == 0 && this.seconds < 30)
            {
                //play HeartBeat
                GameObject.Find("HeartBeat").GetComponent<AudioSource>().Play();
            }
            else if (this.minutes == 0 && this.seconds == 0)
            {
                //stopping HeartBeat
                GameObject.Find("HeartBeat").GetComponent<AudioSource>().Stop();
                //startingflatline
                GameObject.Find("Flatline").GetComponent<AudioSource>().Play();
            }
            else if (this.seconds >= 31 && this.minutes >= 0)
            {
                while (this.soundOn == false)
                {
                if (this.difficulty == "easy")
                {
                    GameObject.Find("easyMusic").GetComponent<AudioSource>().Play();
                    this.soundOn = true;
                } //Starts easy music
                if (this.difficulty == "medium")
                {
                    GameObject.Find("mediumMusic").GetComponent<AudioSource>().Play();
                    this.soundOn = true;
                } //Starts medium music
                if (this.difficulty == "hard")
                {
                    GameObject.Find("hardMusic").GetComponent<AudioSource>().Play();
                    this.soundOn = true;
                } //Starts hard music
                }
            }
           
            yield return new WaitForSeconds(1.0f);
            if (this.seconds == 0)
            {
                if (this.minutes == 0)
                {
                    this.display = "00:00";
                }
                else
                {
                    this.minutes--;
                    this.seconds = 59;
                }
            }
            else
            {
                this.seconds--;
            }
            
        }
    }
}