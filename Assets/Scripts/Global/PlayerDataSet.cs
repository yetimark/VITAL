using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDataSet
{
    // Game Data
    public string difficulty;
    public string skill;
    public string currLevel;
    public string nextLevel;
    public int maxStrikes;

    // Player Data
    public int playerStrikes;
    public int playerPoints;

    // Supply Room Data
    public bool supplyRoom_ChecklistComplete;
    public List<string> checklist;

    // Medication Room Data
    public bool medRoom_ChecklistComplete;
    public List<int> playerResponses_MedCart;

    // Room Completion Data
    public bool supplyRoom_Completion;
    public bool medRoom_Completion;
    public bool skillsRoom_Completion;
}
