using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ========= NewTableChecker ==========
 * - When an Item is placed on the table, it is checked off of both Visual (not-created-yet) & Code-End Checklists (PD.checklist)
 * - A rewritten "TableChecker" script. Refer back to the original script for assistance.
 * 
 * ~Written by Austin Winkler
 * ======================================*/

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
                // Update the Visual & Code-End Checklists
                updateCheckboxes();
                updateChecklist();
            }
        }
    }

    public void updateCheckboxes()
    {
        // Update Visual Checklist
    }
    public void updateChecklist()
    {
        // Update Code-End Checklist
    }
}
