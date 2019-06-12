﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{
    private int strikeNum;      
    private int pointNum;

    public GameObject warningScript;
    public int strikeMax;
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
    public void RemovePoint()
    {
        this.pointNum -= 1;
    }

    public void GoodAction()
    {
        this.pointNum++;
        Debug.Log("POINT" + pointNum);

        GameObject.Find("PointNum").GetComponent<Text>().text = this.pointNum.ToString();
    }

    public void BadAction()
    {
        this.strikeNum++;
        Debug.Log("STRIKE" + strikeNum);

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
