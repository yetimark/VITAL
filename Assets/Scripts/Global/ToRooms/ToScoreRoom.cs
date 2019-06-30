using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToScoreRoom : MonoBehaviour
{
    private GameObject gameManager;
    private bool canUpdate = false;
    private PlayerData PD = null;

    public void Update()
    {
        if (PD == null) { PD = gameManager.GetComponent<PlayerData>(); }

        if (canUpdate && PD.supplyRoom_ChecklistComplete) {
            PD.supplyRoom_Completion = true;
            PD.Save();
            SceneManager.LoadScene("ScoreRoom");
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (PD.supplyRoom_ChecklistComplete)
        {
            PD.supplyRoom_Completion = true;
            PD.Save();
            SceneManager.LoadScene("ScoreRoom");
        }
    }
}
