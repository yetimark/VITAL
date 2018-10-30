using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EasyInputVR.Core;

public class ItemName : MonoBehaviour
{
    private GameObject currentItem = null;
    private string displayText;
    private Button trigger;

	void Awake ()
    {
        this.displayText = this.gameObject.GetComponent<Text>().text;

        //read about button types
        //this.trigger = EasyInputConstants.BUTTON_CONDITION.GearVRTriggerPressed;
	}

    //On_Click
    //On_LongClick
	void Update ()
    {
        if (true)//trigger is pulled
        {
            //this.currentItem = 

            if (this.currentItem)
            {
                this.displayText = this.currentItem.name;
            }
        }
        else
        {
            this.currentItem = null;
            this.displayText = "";
        }
	}
}
