using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checklist : MonoBehaviour
{
    Supplies newSupply = new Supplies();
    private Dictionary<string, bool> checkList = new Dictionary<string, bool>();

    private GameObject checklistPanel, txtboxAdjuster;
    private int index = 0;

    public void Awake()
    {
        this.checklistPanel = GameObject.Find("CheckListPanel");
        txtboxAdjuster = GameObject.Find("checkspot_" + index);

        
    }

    private void CreateSupplyList_PiccLine()
    {
        
        this.checkList.Add("Dressing Change Kit", s0);
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
        //this.checkList.Add(11, obj);
        Debug.Log("PiccLine Checklist Created");
    }

    private void NewToTable(string objectName)
    {
        if (GameObject.Find(objectName).tag != "Player")
        {
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
}
