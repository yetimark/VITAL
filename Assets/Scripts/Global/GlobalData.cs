using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour
{
    public static GlobalData Instance;

    public PlayerInfo savedPlayerData = new PlayerInfo();

    //A "list" of levels (room:SupplyRoom, completed:false)
    public Dictionary<string, bool> roomList = new Dictionary<string, bool>();

    //Variables which will be saved across scenes
    public string roomName;
    public string difficulty;
    public int playerStrikes;
    public int playerPoints;

    public void Awake()
    {
        if (Instance == null) //If there is not a current instance of Game Data, this creates one
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void Start()
    {
        roomList.Add("SupplyRoom", false);
        roomList.Add("MedRoom", false);
    }
}
