using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMeToList : MonoBehaviour
{
    private GameObject gameManager;
    private PlayerData PD;
    
    public GameObject supplyObject;

    private Item item;

    public void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        PD = gameManager.GetComponent<PlayerData>();
        item = supplyObject.GetComponent<Item>();
    }

    public void Start()
    {
        if (PD.skill == "PiccLine")
        {
            foreach (int id in PD.PiccLine)
            {
                if (item.myId == id)
                {
                    Debug.Log("AddedItem to PiccLine");
                    PD.checklist.Add(item.getItemName());
                    Debug.Log(item.getItemName());
                }
            }
        }
        else if (PD.skill == "IVInsertion")
        {
            foreach (int id in PD.IVInsertion)
            {
                if (item.myId == id)
                {
                    PD.checklist.Add(item.getItemName());
                }
            }
        }
        else
        {
            Debug.Log("Skill not selected");
            Debug.Log("Error found in AddMeToList.cs Script");
        }
    }
}
