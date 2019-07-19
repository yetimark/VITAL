using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    private GameObject gameManager;
    private PlayerData PD;

    private GameObject player;

    public GameObject spawnpoint;

    public void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        PD = gameManager.GetComponent<PlayerData>();
        PD.Load();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Start()
    {
        player.transform.position = spawnpoint.transform.position;
    }
}
