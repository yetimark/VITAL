using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public PlayerInfo localPlayerData = new PlayerInfo();

    public int playerPoints;
    public int playerStrikes;

    void Start()
    {
        this.playerPoints = GlobalData.Instance.playerPoints;
        this.playerStrikes = GlobalData.Instance.playerStrikes;
    }
    public void SavePlayerData()
    {
        GlobalData.Instance.savedPlayerData = localPlayerData;
    }
}
