using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TableChecker : MonoBehaviour
{
    private GameObject gameManager;
    private PlayerData PD;

    // Dictionary of objects needed for skill as keyword with a bool to stating if it is on the table already or not
    private Dictionary<string, bool> suppliesChecklist = new Dictionary<string, bool>();

    private int truthCounter;

    public GameObject checklistPanel;
    public bool panelOn = true;
    public GameObject Party;
    private GameObject gameUI;

    public bool handsRinsed = false;
    public bool handsSoaped = false;
    public bool handsDried = false;

    private bool sinkSteps = false;

    public void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        PD = gameManager.GetComponent<PlayerData>();
    }

    private void Update()
    {
        if (handsRinsed && handsDried && handsSoaped)
        {
            sinkSteps = true;
            GameObject.Find("SinkSteps").GetComponent<Image>().enabled = true;
        }
    }

    // Adds all of the objects needed for Picc Line Skill
    private void CreateSupplyList_PiccLine()
    {
        suppliesChecklist.Add("Dressing Change Kit", false);
        suppliesChecklist.Add("Face Mask for Patient", false);
        suppliesChecklist.Add("Securement Device", false);
        suppliesChecklist.Add("Sterile 4x4", false);
        suppliesChecklist.Add("Sterile Drape", false);
        suppliesChecklist.Add("Sterile Gloves", false);
        suppliesChecklist.Add("Tegaderm", false);
        suppliesChecklist.Add("Alcohol Wipes", false);
        suppliesChecklist.Add("Biopatch", false);
        suppliesChecklist.Add("Chux", false);
        suppliesChecklist.Add("Clean Gloves", false);
        Debug.Log("PiccLine Checklist Created");
    }
   
    void Start()
    {
        checklistPanel.SetActive(panelOn); // Change true or false depending upon simulation difficulty
        GameObject.Find("SinkSteps").GetComponent<Image>().enabled = false;

        if (panelOn) // Should be activated on button press for difficulty
        {
            foreach (string itemName in suppliesChecklist.Keys)
            {
                GameObject.Find(itemName + ".").GetComponent<Image>().enabled = false;
            }
        }
    }

    private void NewToTable(string objectName)
    {
        if(GameObject.Find(objectName).tag != "Player")
        {
            //checks objects on table, updates appropriately
          
            if (suppliesChecklist.ContainsKey(objectName) && suppliesChecklist[objectName] == false) // If key is not in dictionary, will it be false for part two if it was the only one?
            {
                suppliesChecklist[objectName] = true;
                truthCounter++;
                Debug.Log("truthCounter" + truthCounter);
                 
                gameUI.GetComponent<UIGame>().GoodAction();
            }
            else
            {
                gameUI.GetComponent<UIGame>().BadAction();
                GameObject.Find(objectName).GetComponent<boxReturn>().ReturnHome(); // return object to shelf
            }   
        }
    }

    private void RemoveFromTable(string objectName) 
    {
        if(GameObject.Find(objectName).tag != "Player")
        {
            if(suppliesChecklist.ContainsKey(objectName) && suppliesChecklist[objectName] == true) // Turns checkmark off if currently correct item is removed from table
            {
                suppliesChecklist[objectName] = false;
                truthCounter--;
                gameUI.GetComponent<UIGame>().RemovePoint();
                Debug.Log("truthCounter" + truthCounter);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            if (sinkSteps)
            {
                
                Debug.Log(other.name);
                NewToTable(other.name);

                GameObject.Find(other.gameObject.name + ".").GetComponent<Image>().enabled = true; // Turn unique checkbox on

                if (truthCounter == suppliesChecklist.Count)
                {
                    GameObject.Find("NewDoor").GetComponent<DoorMover>().OpenDoor();
                    
                    Party.GetComponent<AudioSource>().Play(); //Activates partyMachine
                    Party.GetComponent<ParticleSystem>().Play();

                    PlayerData PD = gameManager.GetComponent<PlayerData>();
                    PD.supplyRoom_ChecklistComplete = true;
                }

            }
            else
            {
                other.GetComponent<boxReturn>().ReturnHome();

                Debug.Log("Make sure to wash, soap and dry your hands!");

                gameUI.GetComponent<UIWarning>().WarningMessage("WashHands");
            }
        }
    }

    //should turn off an object after given time ==================================================================== NOT SURE OF THIS PURPOSE
    private IEnumerator TurnOffObject(GameObject thing, float sec)
    {
        yield return new WaitForSeconds(sec);
        thing.SetActive(false);
    }

    private void OnTriggerExit(Collider other)      //removes items from list when they are taken off of the table
    {
        if (suppliesChecklist.ContainsKey(other.name) && suppliesChecklist[other.name] == true)
        {
            GameObject.Find(other.gameObject.name + ".").GetComponent<Image>().enabled = false; //turn off check box
            RemoveFromTable(other.name);

        }
    }
}
