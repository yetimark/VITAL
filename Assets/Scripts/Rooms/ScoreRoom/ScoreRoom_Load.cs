using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRoom_Load : MonoBehaviour
{
    private GameObject gameManager;
    private PlayerData PD;

    private Text strikes;
    private Text points;

    private GameObject nextLevel;

    public void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        PD = gameManager.GetComponent<PlayerData>();

        strikes = GameObject.FindGameObjectWithTag("ScoreUI_strikes").GetComponent<Text>();
        points = GameObject.FindGameObjectWithTag("ScoreUI_points").GetComponent<Text>();

        nextLevel = GameObject.FindGameObjectWithTag("ScoreUI_nextLevel");
    }

    public void Start()
    {
        strikes.text = PD.playerStrikes.ToString();
        points.text = PD.playerPoints.ToString();

        if (!PD.supplyRoom_Completion)
        {
            nextLevel.SetActive(false);
        }
    }
}
