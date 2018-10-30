using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyInputVR.Core;

public class VRTriggerGrip : MonoBehaviour {

    public bool triggerClick = false;
    
	void Start ()
    {
		
	}
	

	void Update ()
    {

	}

    void LocalClick(ButtonClick button)
    {
        if(button.button == EasyInputConstants.CONTROLLER_BUTTON.GearVRTrigger)
        {
            this.triggerClick = !this.triggerClick;            
        }       
    }



    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Supplies")
        {
            if (triggerClick)
            {
                other.transform.SetParent(this.transform);
            }
            else if (!triggerClick)
            {
                other.transform.SetParent(null);
            }
            else
            {
                Debug.Log("errorWithGrippSelect");
            }

            other.transform.SetParent(this.transform);
            other.GetComponent<Rigidbody>().useGravity = false;
            //LocalClick();
            
            //if(ButtonClick.button == EasyInputConstants.CONTROLLER_BUTTON.GearVRTouchClick)
        }
    }
}
