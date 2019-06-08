using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handWashChecker : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        GameObject.Find("TableSensor").GetComponent<TableChecker>().handsRinsed = true;
    }
}
