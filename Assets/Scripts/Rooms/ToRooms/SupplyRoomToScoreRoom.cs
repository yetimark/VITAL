using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SupplyRoomToScoreRoom : MonoBehaviour
{
    // This script is applied to the teleport box outside of the SupplyRoom door.
    // Once the Player touches the Teleport Pad, it checks to see if the SupplyRoom checklist has been completed.

    private GameObject gameManager;
    private PlayerData PD;

    public void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        PD = gameManager.GetComponent<PlayerData>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (PD.supplyRoom_ChecklistComplete)
            {
                PD.supplyRoom_Completion = true;
                PD.Save();
                SceneManager.LoadScene("ScoreRoom");
            }
        }
    }
}
