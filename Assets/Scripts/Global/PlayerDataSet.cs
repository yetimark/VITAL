using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDataSet
{
    //Game Data
    public string difficulty;
    public int maxStrikes;
    //Player Data
    public int playerStrikes;
    public int playerPoints;

    //Supply Room Data
    public bool supplyRoom_ChecklistComplete;

    //Completion Data
    public bool supplyRoom_Completion;
    public bool medRoom_Completion;
    public bool skillsRoom_Completion;
}
