using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapScript : MonoBehaviour
{
    public GameObject waterStream;

    private void Awake()
    {
        this.waterStream.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hands have been washed");
            GameObject.FindGameObjectWithTag("Table").GetComponent<CheckListChecker>().handsWashed = true;
            this.waterStream.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            this.waterStream.SetActive(false);
        }
    }
}
