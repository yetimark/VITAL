using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescription : MonoBehaviour
{
    private GameObject currentItem = null;

    void Update()
    {
        GameObject currObject = GameObject.Find("OculusGoController").GetComponent<ControllerInteraction>().currObject;

        if (currObject != null)
        {
            this.gameObject.GetComponent<Text>().text = currObject.GetComponent<Text>().text;
        }
        else
        {
            this.gameObject.GetComponent<Text>().text = "";
        }
    }
}
