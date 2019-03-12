using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DoorMover : MonoBehaviour
{
    public float speed = 1f;

    private bool once = false;


    public Transform startRotation;
    public Transform targetRotation;

    private void Start()
    {
        //this.once = false;
    }

    private void ObjectLerp()
    {
        this.gameObject.transform.rotation =
            Quaternion.Lerp(this.startRotation.rotation, this.targetRotation.rotation, Time.deltaTime * this.speed);
    }

    private void PlaySound()
    {
        this.gameObject.GetComponent<AudioSource>().Play();
    }

    public void OpenDoor()
    {
        this.once = true;
        PlaySound();
    }

    public void Update()
    {
        if (this.gameObject.transform.rotation != this.targetRotation.rotation && this.once)
        {
            ObjectLerp();
            Debug.Log("Door is Opening");
        }
    }
}