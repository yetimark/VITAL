﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    //This class holds session data, and loads/saves to the saved data set
    public string roomName;
    public string difficulty;
    public int playerStrikes;
    public int playerPoints;

    public bool supplyRoom;
    public bool medRoom;
    public bool skillsRoom;

    public PlayerDataSet saveData;

    // Start is called before the first frame update
    void Start()
    {
        saveData = new PlayerDataSet();
        Load();
    }

    //saves data to file
    public void Save()
    {
        saveData.roomName = roomName;
        saveData.difficulty = difficulty;
        saveData.playerStrikes = playerStrikes;
        saveData.playerPoints = playerPoints;

        saveData.supplyRoom = supplyRoom;
        saveData.medRoom = medRoom;
        saveData.skillsRoom = skillsRoom;

        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, saveData);
        file.Close();
    }

    //loads data to session
    public void Load()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            GenerateDefaults();
            Save();
            file = File.OpenRead(destination);
        }

        BinaryFormatter bf = new BinaryFormatter();
        saveData = (PlayerDataSet)bf.Deserialize(file);
        file.Close();

        roomName = saveData.roomName;
        difficulty = saveData.difficulty;
        playerStrikes = saveData.playerStrikes;
        playerPoints = saveData.playerPoints;

        supplyRoom = saveData.supplyRoom;
        medRoom = saveData.medRoom;
        skillsRoom = saveData.skillsRoom;
    }


    //sets default values
    public void GenerateDefaults()
    {
        difficulty = null;
        playerStrikes = 0;
        playerPoints = 0;

        supplyRoom = false;
        medRoom = false;
        skillsRoom = false;
    }
}