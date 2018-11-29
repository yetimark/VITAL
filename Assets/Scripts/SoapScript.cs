using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hands have been washed");
            GameObject.FindGameObjectWithTag("Table").GetComponent<CheckListChecker>().handsWashed = true;
        }
    }
}
