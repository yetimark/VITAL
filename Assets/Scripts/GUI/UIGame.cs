using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{
    private int strikeNum;      //changed to private both
    private int pointNum;

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

    public void GoodAction()
    {
        this.pointNum++;
        GameObject.Find("PointNum").GetComponent<Text>().text = this.pointNum.ToString();
    }

    public void BadAction()
    {
        this.strikeNum++;
        GameObject.Find("Strikes").GetComponent<Text>().text = strikeNum.ToString();

        if (this.strikeNum == this.strikeMax)
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
