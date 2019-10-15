using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTableChecker : MonoBehaviour
{
    private GameObject gameManager;
    private PlayerData PD;

    public void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        PD = gameManager.GetComponent<PlayerData>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            foreach (string item in PD.checklist)
            {
                Debug.Log("Item has been added - NewTableChecker");
                //if (other.GetComponent<Item>.getItemName() == item)
                //{
//
 //                   updateCheckboxes();
                //}
            }
        }
    }

    public void updateCheckboxes()
    {

    }
}
