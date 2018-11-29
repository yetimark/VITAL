using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemName : MonoBehaviour
{    
	void Update ()
    {
        GameObject currObject = GameObject.Find("OculusGoController").GetComponent<ControllerInteraction>().currObject;

        if (currObject != null)
        {
            this.gameObject.GetComponent<Text>().text = currObject.name;
            Debug.Log("we have an objection sir!");

        }
        else
        {
            this.gameObject.GetComponent<Text>().text = "";
        }
	}
}
