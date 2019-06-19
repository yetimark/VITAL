using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public string roomName;
    public string difficulty;
    public int playerStrikes;
    public int playerPoints;

    public void Start()
    {
        this.roomName = "Menu";
        this.difficulty = "Null";
        this.playerStrikes = 0;
        this.playerPoints = 0;
    }
}
