using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapTrigger : MonoBehaviour
{

    public void SoapDispenser()
    {
        GameObject.Find("TableSensor").GetComponent<TableChecker>().handsSoaped = true;
    }
}
