using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedCart : MonoBehaviour
{
    private GameObject gameManager;
    private PlayerData PD;

    private string item;
    private int answer;
    private int numCorrect, totalPossible;
    private List<int> answerList;
    private GameObject itemGO;

    public GameObject drawerSpawnPoint;
    public GameObject drawer;

    public void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        PD = gameManager.GetComponent<PlayerData>();
        numCorrect = 0;

        buildAnswerList();
    }

    public void buildAnswerList()
    {   
        if (item == "ITEMNAME")
        //if (true) // Used for testing
        {
            itemGO = GameObject.FindGameObjectWithTag("ITEMNAME");
            answerList = new List<int>() {1,2,3,4};
        }
        else if (PD.skill == "IVInsertion")
        {
            answerList = new List<int>() {2,2,4,1,3};
        }
        // Add additional items here
        else
        {
            answerList = new List<int>() {0,0,0,0};
        } // Default Values
        totalPossible = answerList.Count;
    }

    public void addPlayerResponse(int playerAnswer)
    {
        // Firstly checks to see if the player has input a correct number of responses.
        // Then once the player has met the totalPossible responses, it iterates through and checks the player responses against the answers.
        // LOSS- If there is an incorrect item found, the checks are stopped immediately and the player is both alerted and given a strike. Then the player's responses are reset so the can try again.
        // WIN - If every input from the player is correct, an item has been sucessfully selected.

        if (PD.playerResponses_MedCart.Count < totalPossible)
        {
            PD.playerResponses_MedCart.Add(playerAnswer);
        }
        else
        {
            for (int index = 0; index < totalPossible; index++)
            {
                if (PD.playerResponses_MedCart[index] != answerList[index])
                {
                    // Announce to the user that their entries were incorrect           ---- NEEDS WORK ----
                    // Assign a strike                                                  ---- NEEDS WORK ----
                    PD.playerResponses_MedCart.Clear();
                    numCorrect = 0;
                    break;
                }
                else { numCorrect++; }
                if (numCorrect == totalPossible)
                {
                    spawnItem();
                    drawer.GetComponent<Animator>().Play("Drawer", 0);
                }
            }
        }
    }
    public void spawnItem()
    {
        itemGO.transform.position = drawerSpawnPoint.transform.position;
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
