using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // This class holds session data, and loads/saves to the saved data set
    // Every time a new piece of data needs to be saved, it needs to be added as a Declaration in both PlayerData and PlayerDataSet, in Save() and in Load()


    //GameStats
    public string difficulty;
    public string skill; 
    public int maxStrikes;

    //PlayerStats
    public int playerStrikes;
    public int playerPoints;

    //Supply Room Data
    public bool supplyRoom_ChecklistComplete;

    //CompletedRooms
    public bool supplyRoom_Completion;
    public bool medRoom_Completion;
    public bool skillsRoom_Completion;

    public PlayerDataSet saveData;

    // Start is called before the first frame update
    void Start()
    {
        saveData = new PlayerDataSet();
        Load();
    }

    // Saves data to file
    public void Save()
    {
        saveData.difficulty = difficulty;
        saveData.skill = skill;
        saveData.maxStrikes = maxStrikes;

        saveData.playerStrikes = playerStrikes;
        saveData.playerPoints = playerPoints;

        saveData.supplyRoom_ChecklistComplete = supplyRoom_ChecklistComplete;

        saveData.supplyRoom_Completion = supplyRoom_Completion;
        saveData.medRoom_Completion = medRoom_Completion;
        saveData.skillsRoom_Completion = skillsRoom_Completion;

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

        difficulty = saveData.difficulty;
        skill = saveData.skill;
        maxStrikes = saveData.maxStrikes;

        playerStrikes = saveData.playerStrikes;
        playerPoints = saveData.playerPoints;

        supplyRoom_ChecklistComplete = saveData.supplyRoom_ChecklistComplete;

        supplyRoom_Completion = saveData.supplyRoom_Completion;
        medRoom_Completion = saveData.medRoom_Completion;
        skillsRoom_Completion = saveData.skillsRoom_Completion;
    }


    //sets default values
    public void GenerateDefaults()
    {
        difficulty = null;
        skill = null;
        maxStrikes = 0;

        playerStrikes = 0;
        playerPoints = 0;

        supplyRoom_ChecklistComplete = false;

        supplyRoom_Completion = false;
        medRoom_Completion = false;
        skillsRoom_Completion = false;
    }
}
