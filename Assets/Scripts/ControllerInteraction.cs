using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInteraction : MonoBehaviour
{
    //this script allows objects that the player is pointing at to be referenced

        //this is the object being pointed at (only for interactable items)
    public GameObject currObject;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Supplies")
        {
            this.currObject = other.gameObject;
        }
        else if (other.tag == "PaperTowel")
        {
            GameObject.Find("Paper").GetComponent<PaperSpawner>().only = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Supplies" || other.tag == "PaperTowel")
        {
            this.currObject = null;


        }
    }



}
