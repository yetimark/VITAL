using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int minutes;
    public int seconds;
    public string difficulty;

    private string convertedTime; //change this value before runtime
    private string display;
    public bool soundOn = false;

    void Start ()
    {
        StartCoroutine(CountdownStart(this.minutes, this.seconds, this.difficulty));
    }

    void Update ()
    {
        GameObject.Find("ClockText").GetComponent<Text>().text = this.display;
        Debug.Log(this.minutes);
        Debug.Log(this.seconds);
        Debug.Log(this.display);
        
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
                //play HeartBeat
                GameObject.Find("HeartBeat").GetComponent<AudioSource>().Play();
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
                else if (this.difficulty == "medium")
                {
                    GameObject.Find("mediumMusic").GetComponent<AudioSource>().Play();
                    this.soundOn = true;
                } //Starts medium music
                else if (this.difficulty == "hard")
                {
                    GameObject.Find("hardMusic").GetComponent<AudioSource>().Play();
                    this.soundOn = true;
                } //Starts hard music
                }
            }
            if (this.minutes == 0 && this.seconds == 0)
            {
                //stopping HeartBeat
                GameObject.Find("HeartBeat").GetComponent<AudioSource>().Stop();
                //startingflatline
                GameObject.Find("Flatline").GetComponent<AudioSource>().Play();
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