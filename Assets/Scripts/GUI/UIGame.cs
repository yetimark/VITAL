using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject warningScript;
    public int itemChances;

    private GameObject points;
    private GameObject strikes;

    private void Awake()
    {
        warningScript = GameObject.FindGameObjectWithTag("Game UI");
        points = GameObject.FindGameObjectWithTag("Points");
        strikes = GameObject.FindGameObjectWithTag("Strikes");
    }

    private void Start()
    {
        PlayerData PD = gameManager.GetComponent<PlayerData>();
        PD.playerPoints = 0;
        points.GetComponent<Text>().text = PD.playerPoints.ToString();
        strikes.GetComponent<Text>().text = PD.playerStrikes.ToString();

    }
    public void RemovePoint()
    {
        PlayerData PD = gameManager.GetComponent<PlayerData>();
        PD.playerPoints -= 1;
    }

    public void GoodAction()
    {
        PlayerData PD = gameManager.GetComponent<PlayerData>();
        PD.playerPoints++;
        Debug.Log("POINT" + PD.playerPoints);

        points.GetComponent<Text>().text = PD.playerPoints.ToString();
    }

    public void BadAction()
    {
        PlayerData PD = gameManager.GetComponent<PlayerData>();
        PD.playerStrikes++;
        Debug.Log("STRIKE" + PD.playerStrikes);
        GameObject.Find("Strikes").GetComponent<Text>().text = PD.playerStrikes.ToString();

        if (PD.playerStrikes == PD.maxStrikes)
        {
            warningScript.GetComponent<UIWarning>().WarningMessage("GameOver");
            Time.timeScale = 0f;
        }
        else
        {
            warningScript.GetComponent<UIWarning>().WarningMessage("Strike");
        }
    }
}
