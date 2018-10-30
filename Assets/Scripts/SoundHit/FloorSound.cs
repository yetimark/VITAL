using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSound : MonoBehaviour {


    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Supplies")
        {
            this.gameObject.GetComponent<AudioSource>().Play();
            //Debug.Log("there is noise");
        }
    }

}
