using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handWashChecker : MonoBehaviour
{
    private GameObject tblSensor, gameUI;

    public void Awake()
    {
        tblSensor = GameObject.Find("TableSensor");
        gameUI = GameObject.Find("Game UI");
    }
    public void OnTriggerEnter(Collider other)
    {
        if (tblSensor.GetComponent<TableChecker>().handsSoaped == true)
        {
            tblSensor.GetComponent<TableChecker>().handsRinsed = true;
        }
        else
        {
            gameUI.GetComponent<UIWarning>().WarningMessage("IncorrectOrder");
        }
    }
}
