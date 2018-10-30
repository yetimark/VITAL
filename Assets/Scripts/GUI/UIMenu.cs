using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    private GameObject skills;
    private GameObject duration;
    private GameObject difficulty;

    private void Awake()
    {
        this.skills = GameObject.Find("SkillPanel");
        this.duration = GameObject.Find("DurationPanel");
        this.difficulty = GameObject.Find("DifficultyPanel");
    }

    void Start ()
    {
		
	}
	
    public void ToDuration()
    {
        this.duration.SetActive(true);
        this.skills.SetActive(false);
    }

    public void ToDifficulty()
    {
        this.difficulty.SetActive(true);
        this.duration.SetActive(false);
    }

    public void ToGame()
    {
        this.difficulty.SetActive(false);
    }

    public void Novice()
    {
        Debug.Log("novice");
        GameObject.Find("Game UI").GetComponent<UIGame>().strikeDifficulty = -1;    //strikeNum
        //itemSpawn low
    }

    public void Competent()
    {
        Debug.Log("competent");
        GameObject.Find("Game UI").GetComponent<UIGame>().strikeDifficulty = 3;
        //checklist names are hidden until correct
        //item spawn med
    }

    public void Expert()
    {
        Debug.Log("expert");
        GameObject.Find("Game UI").GetComponent<UIGame>().strikeDifficulty = 2;
        //no checkList visual
        //tons of extra items       item spawn high
    }

}
