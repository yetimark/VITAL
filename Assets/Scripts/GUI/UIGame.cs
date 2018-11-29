using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{
    public int strikeNum = 0;
    public int pointNum;
    public bool good = false;
    public bool bad = false;
    public GameObject warningScript;
    public int strikeMax;//for some silliness below. Should be changed to difficulty classes to cover all variable needed to be changed?
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

    }

    void Update ()      //there is a better way to do this than using update        #FIXME: Responsible for adding and subtracting points. Also, takes care of strikes and some basic messages
    {
        if (this.good)
        {
            this.good = false;
            this.pointNum++;
            GameObject.Find("PointNum").GetComponent<Text>().text = this.pointNum.ToString(); 
        }
        else if (this.bad)
        {
            this.bad = false;
            this.pointNum--;
            GameObject.Find("PointNum").GetComponent<Text>().text = this.pointNum.ToString();

            this.strikeNum++;
            GameObject.Find("Strikes").GetComponent<Text>().text = strikeNum.ToString();

            if (this.strikeMax == -1)     //novice difficulty strike set to -1
            {
                //not really needed
            }
            else if(this.strikeMax >= 1)       //strikeMax is be set when difficulty chosen
            {
                if(this.strikeNum == this.strikeMax)
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
