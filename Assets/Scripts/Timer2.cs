using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer2 : MonoBehaviour
{
    //ATTACH AUDIO FOR FLATLINE
    public int minutesTwo = 1;
    public int secondsTwo = 30;
    public string displayTwo;

    void Start()
    {
        StartCoroutine(CountdownStartTwo(this.minutesTwo, this.secondsTwo));
    }

    void Update()
    {
        GameObject.FindGameObjectWithTag("Timer2").GetComponent<Text>().text = this.displayTwo;
    }
    public IEnumerator CountdownStartTwo(float minutes, float seconds)
    {
        while (secondsTwo > -1)
        {
            if (secondsTwo <= 9)
            {
                this.displayTwo = minutesTwo + ":0" + secondsTwo;
            }
            else
            {
                this.displayTwo = minutesTwo + ":" + secondsTwo;
            }
            if (minutes == 0 && seconds == 0)
            {
                this.gameObject.GetComponent<AudioSource>().Play();
            }
            yield return new WaitForSeconds(1.0f);
            if (secondsTwo == 0)
            {
                if (minutesTwo == 0)
                {
                    this.displayTwo = "00:00";
                }
                else
                {
                    minutesTwo--;
                    secondsTwo = 59;
                }
            }
            else
            {
                secondsTwo--;
            }
        }
    }
}