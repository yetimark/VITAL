﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoapScript : MonoBehaviour
{
    public GameObject waterStream;
    private bool washedOnce = true;

    private void Awake()
    {
        this.waterStream.SetActive(false);
    }
    

    public void FaucetButtonPressDown()
    {
        
        Debug.Log("Hands have been washed");
        //GameObject.FindGameObjectWithTag("Table").GetComponent<CheckListChecker>().handsWashed = true;
        GameObject.FindGameObjectWithTag("Table").GetComponent<TableChecker>().handsWashed = true;
        this.waterStream.SetActive(true);

        if (this.washedOnce)
        {
            Debug.Log("2");
            this.washedOnce = false;
            GameObject.Find("WashedHands").GetComponent<Image>().enabled = true;

            //Strikes and points taken care of in following method
            GameObject.Find("Game UI").GetComponent<UIGame>().GoodAction();
        }
        
    }

    public void FaucetButtonPressUp()
    {
        this.waterStream.SetActive(false);
    }

    
}
