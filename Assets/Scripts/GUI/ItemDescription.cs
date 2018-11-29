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
       this.displayMessage = this.gameObject.GetComponent<Text>().text;
    }

    void Update()
    {
        GameObject currObject = GameObject.Find("OculusGoController").GetComponent<ControllerInteraction>().currObject;

        if (currObject != null)
        {
            this.displayMessage = this.currentItem.name;
        }
        else
        {
            this.displayMessage = "";
        }
    }
}
