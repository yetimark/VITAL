using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableChecker : MonoBehaviour
{
    //dictionary of objects needed for skill as keyword with a bool to stating if it is on the table already or not
    private Dictionary<string, bool> piccLine = new Dictionary<string, bool>();
    private int truthCounter;

    public GameObject listPanel;
    public bool panelOn = true;
    public GameObject Party;

    private bool washedOnce = true;

    //for requiring handwashing before item placement on table
    //being used as Singletons and gates at line 82
    public bool handsWashed = false;
    //public bool handsDried = true;                                               //#FIXME: should be false?

    //private bool handsRinsed = false;

    void Awake()
    {
        Party = GameObject.FindGameObjectWithTag("Party");
        Party.GetComponent<ParticleSystem>().Pause();
        this.listPanel = GameObject.Find("CheckListPanel");

        AddObjectsToPiccLine();
    }

    //adds all of the objects needed for Picc Line Skill
    private void AddObjectsToPiccLine()
    {
        this.piccLine.Add("Dressing Change Kit", false);
        this.piccLine.Add("Face Mask for Patient", false);
        this.piccLine.Add("Securement Device", false);
        this.piccLine.Add("Sterile 4x4", false);
        this.piccLine.Add("Sterile Drape", false);
        this.piccLine.Add("Sterile Gloves", false);
        this.piccLine.Add("Tegaderm", false);
        this.piccLine.Add("Alcohol Wipes", false);
        this.piccLine.Add("Biopatch", false);
        this.piccLine.Add("Chux", false);
        this.piccLine.Add("Clean Gloves", false);
    }

    void Start()
    {
        this.listPanel.SetActive(this.panelOn);     //change true or false depending upon simulation difficulty
        GameObject.Find("WashedHands").GetComponent<Image>().enabled = false;

        if (this.panelOn)       //should be activated on button press for difficulty 
        {

            foreach (string itemName in this.piccLine.Keys)      //#FIXME:    piccLine should change upon skill selection
            {
                //Debug.Log(item);
                GameObject.Find(itemName + ".").GetComponent<Image>().enabled = false;
            }
        }
    }

    private void NewToTable(string objectName)
    {
        if(GameObject.Find(objectName).tag != "Player")
        {
            //checks objects on table, updates appropriately,               FIXME:??    and delivers strikes and points.
          
            if (this.piccLine.ContainsKey(objectName) && this.piccLine[objectName] == false)        //if key is not in dictionary, will it be false for part two if it was the only one?
            {
                this.piccLine[objectName] = true;
                this.truthCounter++;
                Debug.Log("truthCounter" + truthCounter);

                GameObject.Find("Game UI").GetComponent<UIGame>().GoodAction();
            }
            else
            {
                GameObject.Find("Game UI").GetComponent<UIGame>().BadAction();
                //return object to shelf
                GameObject.Find(objectName).GetComponent<boxReturn>().ReturnHome();
            }   
        }

    }

    private void RemoveFromTable(string objectName)
    {
        if(GameObject.Find(objectName).tag != "Player")
        {
            if(this.piccLine.ContainsKey(objectName) && this.piccLine[objectName] == true)
            {
                this.piccLine[objectName] = false;
                this.truthCounter--;
                Debug.Log("truthCounter" + truthCounter);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        //if(this.handsSoaped && this.handsRinsed && this.handsDried)
        //then player is code side allowed to place objects on the table\
        //#FixMe: Add a warning when placing things on table without doing the sink things
        if(other.tag != "Player")
        {
            if (this.handsWashed)
            {
                Debug.Log("1");
                //green for washed hands            //seperate method for other checks like handwashing
                

                Debug.Log(other.name);
                NewToTable(other.name);
                
                //turn unique checkbox on
                GameObject.Find(other.gameObject.name + ".").GetComponent<Image>().enabled = true; 

                if (this.truthCounter == this.piccLine.Count)
                {
                    GameObject.Find("NewDoor").GetComponent<DoorMover>().OpenDoor();
                    //Activates partyMachine
                    Party.GetComponent<AudioSource>().Play();
                    Party.GetComponent<ParticleSystem>().Play();
                }

            }
            else        //warning prompt for washing hands and return object to starting position
            {
                //      #FIXME:     Perhaps have the object display it was wrong, wait, and them move
                other.GetComponent<boxReturn>().ReturnHome();

                Debug.Log("Make sure to wash and dry your hands!");

                GameObject.Find("Game UI").GetComponent<UIWarning>().WarningMessage("DryHands");

                //Strikes and points taken care of in following method
            //    GameObject.Find("Game UI").GetComponent<UIGame>().BadAction();
            }
        }
    }



    //should turn off an object after given time
    private IEnumerator TurnOffObject(GameObject thing, float sec)
    {
        yield return new WaitForSeconds(sec);
        thing.SetActive(false);
    }

    private void OnTriggerExit(Collider other)      //removes items from list when they are taken off of the table
    {
        if (this.piccLine.ContainsKey(other.name) && this.piccLine[other.name] == true)
        {
            GameObject.Find(other.gameObject.name + ".").GetComponent<Image>().enabled = false; //turn off check box
            RemoveFromTable(other.name);
        }
    }
}
