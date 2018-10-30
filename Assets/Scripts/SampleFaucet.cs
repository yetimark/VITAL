using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SampleFaucet : MonoBehaviour
{

    void OnTriggerEnter (Collider other)
    {
        this.gameObject.GetComponent<ParticleSystem>().Play();
        Debug.Log("do stuff");
        this.gameObject.GetComponent<AudioSource>().Play();
    }

    private void OnTriggerExit(Collider other)
    {
        this.GetComponent<ParticleSystem>().Pause();
        //this.GetComponent<ParticleSystem>().Clear();
    }
}
