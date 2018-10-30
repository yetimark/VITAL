using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DoorMover : MonoBehaviour
{
    public float speed = 1f;
    
    private bool go = false;
    private bool once = true;
    

    public Transform startRotation;
    public Transform targetRotation;


    void ObjectLerp()
    {
        this.gameObject.transform.rotation = 
            Quaternion.Lerp(this.startRotation.rotation, this.targetRotation.rotation, Time.deltaTime * this.speed);
    }

    void PlaySound()
    {
        if (this.go)
        {
            this.once = false;
            this.gameObject.GetComponent<AudioSource>().Play();
        }
    }


    private void Update()       //use this
    {
        this.go = GameObject.FindGameObjectWithTag("Table").GetComponent<CheckListChecker>().door;

        if (this.go)        //activate this.go in on table competion
        {
            if (this.gameObject.transform.rotation != this.targetRotation.rotation)
            {
                ObjectLerp();
                PlaySound();
                Debug.Log("it happened");
            }
        }
    }
}