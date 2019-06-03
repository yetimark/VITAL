using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int minutes;
    public int seconds;
    public string difficulty;

    private string convertedTime; //Change this value before runtime
    private string display;
    public bool soundOn = false;

    void Start ()
    {
        StartCoroutine(CountdownStart(this.minutes, this.seconds, this.difficulty));
    }

    void Update ()
    {
        GameObject.Find("ClockText").GetComponent<Text>().text = this.display;    
	}

    public IEnumerator CountdownStart(float minutes, float seconds, string difficulty)
    {
        while (this.seconds > -1)
        {
            if (this.seconds <= 9 && this.seconds != -1)
            {
                this.display = this.minutes + ":0" + this.seconds;
            }
            else
            {
                this.display = this.minutes + ":" + this.seconds;
            }
            if (this.minutes == 0 && this.seconds == 30)
            {
                if (this.difficulty == "easy")
                {
                    GameObject.Find("easyMusic").GetComponent<AudioSource>().Stop();
                } 
                if (this.difficulty == "medium")
                {
                    GameObject.Find("mediumMusic").GetComponent<AudioSource>().Stop();
                } 
                if (this.difficulty == "hard")
                {
                    GameObject.Find("hardMusic").GetComponent<AudioSource>().Stop();
                } 
            }
            else if (this.minutes == 0 && this.seconds < 30)
            {
                GameObject.Find("HeartBeat").GetComponent<AudioSource>().Play(); //Heartbeat starts
            }
            else if (this.seconds >= 31 && this.minutes >= 0) //Plays the specified music of its difficulty UNTIL 30 seconds remain
            {
                while (this.soundOn == false)
                {
                    if (this.difficulty == "easy") //Starts Difficulty:EASY music
                    {
                        GameObject.Find("easyMusic").GetComponent<AudioSource>().Play();
                        this.soundOn = true;
                    } 
                    else if (this.difficulty == "medium") //Starts Difficulty:MEDIUM music
                    {
                        GameObject.Find("mediumMusic").GetComponent<AudioSource>().Play();
                        this.soundOn = true;
                    } 
                    else if (this.difficulty == "hard") //Starts Difficulty:HARD music
                    {
                        GameObject.Find("hardMusic").GetComponent<AudioSource>().Play();
                        this.soundOn = true;
                    } 
                }
            }
            if (this.minutes == 0 && this.seconds == 0) 
            {
                GameObject.Find("HeartBeat").GetComponent<AudioSource>().Stop(); //HeartBeat stops
                GameObject.Find("Flatline").GetComponent<AudioSource>().Play();  //Flatline starts
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