using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OculusQuestGrab : MonoBehaviour
{
    /*---------- Blaine M Andrada ----------

    Created 10/15/19 for VITAL
    This script is one of the "new" solutions 
    to putting VITAL on the Oculus Quest

    This script allows for object interaction
    of a hand

    Followed Tutorial: https://circuitstream.com/blog/grab-oculus/

    --------------------------------------*/

    public GameObject CollidingObject;
    public GameObject objectInHand;

    public void onTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Rigidbody>())
        {
            Debug.Log(other.gameObject);
            CollidingObject = other.gameObject;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        CollidingObject = null;
    }

    private void Update()
    {
        if(OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.2)
        {
            GrabObject();
            GameObject.Find("ChangingText").GetComponent<Text>().text = "Grabbing Object?";
        }

        if(OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) < 0.2)
        {
            ReleaseObject();
            GameObject.Find("ChangingText").GetComponent<Text>().text = "Releasing Object?";
        }
    }

    public void GrabObject()
    {
        objectInHand = CollidingObject;
        objectInHand.transform.SetParent(this.transform);
        objectInHand.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void ReleaseObject()
    {
        objectInHand.GetComponent<Rigidbody>().isKinematic = false;
        objectInHand.transform.SetParent(null);
        objectInHand = null;
    }
}
