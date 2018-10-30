using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DoorSound : MonoBehaviour
{
    private Quaternion home;
    private bool once = true;

    private void Start()
    {
        this.gameObject.transform.rotation = this.home;
    }

    private void Update()
    {
        if(this.gameObject.transform.rotation != this.home && this.once)
        {
            this.once = false;
            this.gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("DoorSound");
        }
    }

}
