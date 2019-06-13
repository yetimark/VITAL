using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checklist : MonoBehaviour
{
    Supplies newSupply = new Supplies();
    private Dictionary<int, object> checkList = new Dictionary<int, object>();

    private GameObject checklistPanel, txtboxAdjuster;
    private int index = 0;


    public void Awake()
    {
        this.checklistPanel = GameObject.Find("CheckListPanel");
        txtboxAdjuster = GameObject.Find("checkspot_" + index);


    }

    private void CreateSupplyList_PiccLine()
    {
        this.checkList.Add(0, newSupply.name);
        this.checkList.Add(1, false);
        this.checkList.Add(2, false);
        this.checkList.Add(3, false);
        this.checkList.Add(4, false);
        this.checkList.Add(5, false);
        this.checkList.Add(6, false);
        this.checkList.Add(7, false);
        this.checkList.Add(8, false);
        this.checkList.Add(9, false);
        this.checkList.Add(10, false);
        //this.checkList.Add(11, obj);
        Debug.Log("PiccLine Checklist Created");
    }
}
