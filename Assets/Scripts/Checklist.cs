using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checklist : MonoBehaviour
{
    private Dictionary<int, object> checkList = new Dictionary<int, object>();

    private GameObject checklistPanel, txtboxAdjuster;
    private int index = 0;

    public void Awake()
    {
        this.checklistPanel = GameObject.Find("CheckListPanel");
        txtboxAdjuster = GameObject.Find("checkspot_" + index);
    }

}
