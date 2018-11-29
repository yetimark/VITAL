using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescription : MonoBehaviour
{
    private GameObject currentItem = null;
    private string displayMessage;


    void Awake()
    {
       this.displayMessage = "";
    }

    void Update()
    {
        GameObject currObject = GameObject.Find("OculusGoController").GetComponent<ControllerInteraction>().currObject;

        if (currObject != null)
        {
            this.displayMessage = currObject.GetComponent<Text>().text;
        }
        else
        {
            this.displayMessage = "";
        }
    }
}
