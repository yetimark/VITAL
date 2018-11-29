﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemName : MonoBehaviour
{
    private GameObject currentItem = null;
    private string displayText;


	void Awake ()
    {
        this.displayText = this.gameObject.GetComponent<Text>().text;
	}

	void Update ()
    {
        GameObject currObject = GameObject.Find("OculusGoController").GetComponent<ControllerInteraction>().currObject;

        if(currObject != null)
        {
            this.displayText = this.currentItem.name;
        }
        else
        {
            this.displayText = "";
        }
	}
}
