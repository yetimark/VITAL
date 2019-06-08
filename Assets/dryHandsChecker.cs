using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dryHandsChecker : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        this.GetComponent<AudioSource>().Play();
        GameObject.Find("TableSensor").GetComponent<TableChecker>().handsDried = true;
    }
    public void OnTriggerExit(Collider other)
    {
        this.GetComponent<AudioSource>().Stop();
    }
}
