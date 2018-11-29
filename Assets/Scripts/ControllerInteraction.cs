using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyInputVR.Misc;

public class ControllerInteraction : MonoBehaviour
{
    //this script allows objects that the player is pointing at to be referenced

        //this is the object being pointed at (only for interactable items)
    public GameObject currObject;
    public bool oneObject = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Supplies")
        {
            this.currObject = other.gameObject;
            this.oneObject = true;
        }
        else if (other.tag == "PaperTowel")
        {
            GameObject.Find("Paper").GetComponent<PaperSpawner>().only = true;
            this.oneObject = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Supplies" || other.tag == "PaperTowel")
        {
            this.currObject = null;
            this.oneObject = false;

        }
    }



}
