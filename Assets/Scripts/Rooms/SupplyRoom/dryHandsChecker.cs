using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class dryHandsChecker : MonoBehaviour
{
    private GameObject tblChecker;
    private GameObject gameUI;
    public void Awake()
    {
        tblChecker = GameObject.Find("TableSensor");
        gameUI = GameObject.Find("Game UI");
    }
    public void OnTriggerEnter(Collider other)
    {
        this.GetComponent<AudioSource>().Play();
        if (tblChecker.GetComponent<TableChecker>().handsRinsed == true)
        {
            Debug.Log("Hands are dried");
            tblChecker.GetComponent<TableChecker>().handsDried = true;
        }
        else
        {
            gameUI.GetComponent<UIWarning>().WarningMessage("IncorrectOrder");
        }
    }
    public void OnTriggerExit(Collider other)
    {
        this.GetComponent<AudioSource>().Stop();
    }
}
