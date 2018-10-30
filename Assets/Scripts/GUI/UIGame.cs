using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{
    public int strikeNum;
    public int pointNum;
    public bool good = false;
    public bool bad = false;
    public GameObject warningScript;
    public int strikeDifficulty;
    public int itemChances;

    private void Awake()
    {
        this.warningScript = GameObject.Find("Game UI");
    }

    private void Start()
    {
        this.pointNum = 0;
        GameObject.Find("PointNum").GetComponent<Text>().text = this.pointNum.ToString();
        GameObject.Find("Strikes").GetComponent<Text>().text = this.strikeNum.ToString();
        //this.strikeNum = some variable from difficulty

    }

    void Update ()
    {
        if (good)
        {
            this.good = false;
            this.pointNum++;
            GameObject.Find("PointNum").GetComponent<Text>().text = this.pointNum.ToString(); 
        }
        else if (bad)
        {
            this.bad = false;
            this.pointNum--;
            GameObject.Find("PointNum").GetComponent<Text>().text = this.pointNum.ToString();

            this.strikeNum++;
            GameObject.Find("Strikes").GetComponent<Text>().text = strikeNum.ToString();

            if (this.strikeDifficulty == -1)     //novice difficulty strike set to -1
            {
                //nothing for now.. somehow get rid of strike panel?
            }
            else if(this.strikeDifficulty >= 1)       //strikeDifficulty will be set when difficulty chosen
            {
                if(this.strikeNum == this.strikeDifficulty)
                {
                    this.warningScript.GetComponent<UIWarning>().WarningMessage("GameOver");
                    Time.timeScale = 0f;
                }
                else
                {
                    this.warningScript.GetComponent<UIWarning>().WarningMessage("Strike");
                }
            }
        }
    }
}
