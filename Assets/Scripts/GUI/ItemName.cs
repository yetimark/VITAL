using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemName : MonoBehaviour
{
    private string displayText;
    

	void Awake ()
    {
        this.displayText = "";
	}

	void Update ()
    {
        GameObject currObject = GameObject.Find("OculusGoController").GetComponent<ControllerInteraction>().currObject;

        if(currObject != null)
        {
            this.displayText = currObject.name;
        }
        else
        {
            this.displayText = "";
        }
	}
}
