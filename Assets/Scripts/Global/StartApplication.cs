using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartApplication : MonoBehaviour
{
    private GameObject gameManager;
    private PlayerData PD;
    
    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        PD = gameManager.GetComponent<PlayerData>();
    }
}
