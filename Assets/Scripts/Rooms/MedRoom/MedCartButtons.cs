using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedCartButtons : MonoBehaviour
{
    private GameObject gameManager;
    private PlayerData PD;

    private int answer;
    private List<int> answerList;

    public void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        PD = gameManager.GetComponent<PlayerData>();

        buildAnswerList();
    }

    public void buildAnswerList()
    {
        if (PD.skill == "PiccLine")
        {
            answerList = new List<int>() {1,2,3,4};
        }
        else if (PD.skill == "IVInsertion")
        {
            answerList = new List<int>() {2,2,4,1};
        }
        // Add additional skill checks here
        else
        {
            answerList = new List<int>() {0,0,0,0};
        }
    }

    public void addPlayerResponse(int playerAnswer)
    {
        if (PD.playerResponses_MedCart.Count < 4)
        {
            PD.playerResponses_MedCart.Add(playerAnswer);
        }
        else
        {
            for (int index = 0; index < 4; index++)
            {
                if (PD.playerResponses_MedCart[index] != answerList[index])
                {
                    // Announce to the user that their entries were incorrect
                    // Assign a strike
                    PD.playerResponses_MedCart.Clear();
                    break;
                }
            }
        }
    }
    public void Red_Button()
    {
        answer = 1;
        addPlayerResponse(answer);
    }

    public void Yellow_Button()
    {
        answer = 2;
        addPlayerResponse(answer);
    }

    public void Blue_Button()
    {
        answer = 3;
        addPlayerResponse(answer);
    }

    public void Green_Button()
    {
        answer = 4;
        addPlayerResponse(answer);
    }
}
