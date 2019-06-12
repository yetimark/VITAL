using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TableChecker : MonoBehaviour
{
    // Dictionary of objects needed for skill as keyword with a bool to stating if it is on the table already or not
    private Dictionary<string, bool> checkList = new Dictionary<string, bool>();
    private int truthCounter;

    public GameObject checklistPanel;
    public bool panelOn = true;
    public GameObject Party;
    private GameObject gameUI;

    public bool handsRinsed = false;
    public bool handsSoaped = false;
    public bool handsDried = false;

    private bool sinkSteps = false;

    private void Update()
    {
        if (this.handsRinsed && this.handsDried && this.handsSoaped)
        {
            this.sinkSteps = true;
            GameObject.Find("SinkSteps").GetComponent<Image>().enabled = true;
        }
    }

    void Awake()
    {
        gameUI = GameObject.Find("Game UI");
        Party = GameObject.FindGameObjectWithTag("Party");
        Party.GetComponent<ParticleSystem>().Pause();
        this.checklistPanel = GameObject.Find("CheckListPanel");

        CreateSupplyList_PiccLine();
    }

    // Adds all of the objects needed for Picc Line Skill
    private void CreateSupplyList_PiccLine()
    {
        this.checkList.Add("Dressing Change Kit", false);
        this.checkList.Add("Face Mask for Patient", false);
        this.checkList.Add("Securement Device", false);
        this.checkList.Add("Sterile 4x4", false);
        this.checkList.Add("Sterile Drape", false);
        this.checkList.Add("Sterile Gloves", false);
        this.checkList.Add("Tegaderm", false);
        this.checkList.Add("Alcohol Wipes", false);
        this.checkList.Add("Biopatch", false);
        this.checkList.Add("Chux", false);
        this.checkList.Add("Clean Gloves", false);
        Debug.Log("PiccLine Checklist Created");
    }

    void Start()
    {
        this.checklistPanel.SetActive(this.panelOn); // Change true or false depending upon simulation difficulty
        GameObject.Find("SinkSteps").GetComponent<Image>().enabled = false;

        if (this.panelOn) // Should be activated on button press for difficulty
        {
            foreach (string itemName in this.checkList.Keys)      //#FIXME:    piccLine should change upon skill selection
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
          
            if (this.checkList.ContainsKey(objectName) && this.checkList[objectName] == false) // If key is not in dictionary, will it be false for part two if it was the only one?
            {
                this.checkList[objectName] = true;
                this.truthCounter++;
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
            if(this.checkList.ContainsKey(objectName) && this.checkList[objectName] == true) // Turns checkmark off if currently correct item is removed from table
            {
                this.checkList[objectName] = false;
                this.truthCounter--;
                gameUI.GetComponent<UIGame>().RemovePoint();
                Debug.Log("truthCounter" + truthCounter);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        //if(this.handsSoaped && this.handsRinsed && this.handsDried)
        //then player is code side allowed to place objects on the table\

        if (other.tag != "Player")
        {
            if (this.sinkSteps)
            {
                
                Debug.Log(other.name);
                NewToTable(other.name);

                GameObject.Find(other.gameObject.name + ".").GetComponent<Image>().enabled = true; // Turn unique checkbox on

                if (this.truthCounter == this.checkList.Count)
                {
                    GameObject.Find("NewDoor").GetComponent<DoorMover>().OpenDoor();
                    
                    Party.GetComponent<AudioSource>().Play(); //Activates partyMachine
                    Party.GetComponent<ParticleSystem>().Play();
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
        if (this.checkList.ContainsKey(other.name) && this.checkList[other.name] == true)
        {
            GameObject.Find(other.gameObject.name + ".").GetComponent<Image>().enabled = false; //turn off check box
            RemoveFromTable(other.name);

        }
    }
}
