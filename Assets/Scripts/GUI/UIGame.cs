using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{
    private GameObject gameManager;
    private PlayerData PD;

    public GameObject warningScript;
    public int itemChances;

    private GameObject points;
    private GameObject strikes;

    private void Awake()
    {
        warningScript = GameObject.FindGameObjectWithTag("Game UI");
        points = GameObject.FindGameObjectWithTag("Points");
        strikes = GameObject.FindGameObjectWithTag("Strikes");

        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        PD = gameManager.GetComponent<PlayerData>();
    }

    private void Start()
    {
        PD.playerPoints = 0;
        points.GetComponent<Text>().text = PD.playerPoints.ToString();
        strikes.GetComponent<Text>().text = PD.playerStrikes.ToString();
    }
    public void RemovePoint()
    {
        PD.playerPoints -= 1;
    }

    public void GoodAction()
    {
        PD.playerPoints++;
        Debug.Log("POINT" + PD.playerPoints);

        points.GetComponent<Text>().text = PD.playerPoints.ToString();
    }

    public void BadAction()
    {
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
