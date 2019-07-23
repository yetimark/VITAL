using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // This class holds session data, and loads/saves to the saved data set
    // Every time a new piece of data needs to be saved, it needs to be added as a Declaration in both PlayerData and PlayerDataSet, in Save() and in Load()

    // GameStats
    public string difficulty;
    public string skill;
    public string currLevel;
    public string nextLevel;
    public int maxStrikes;

    // PlayerStats
    public int playerStrikes;
    public int playerPoints;

    // Supply Room Data
    public bool supplyRoom_ChecklistComplete;
    public List<GameObject> checklist;

    // Supply Room Data - NOT SAVED
    public List<int> PiccLine = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    public List<int> IVInsertion = new List<int> { 12, 17, 18, 21 };

    // Medication Room Data
    public bool medRoom_ChecklistComplete;
    public List<int> playerResponses_MedCart;

    // CompletedRooms
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
        // GameStats
        saveData.difficulty = difficulty;
        saveData.skill = skill;
        saveData.currLevel = currLevel;
        saveData.nextLevel = nextLevel;
        saveData.maxStrikes = maxStrikes;

        // PlayerStats
        saveData.playerStrikes = playerStrikes;
        saveData.playerPoints = playerPoints;

        // Supply Room Data
        saveData.supplyRoom_ChecklistComplete = supplyRoom_ChecklistComplete;
        saveData.checklist = checklist;

        // Medication Room Data
        saveData.medRoom_ChecklistComplete = medRoom_ChecklistComplete;
        saveData.playerResponses_MedCart = playerResponses_MedCart;

        // Completed Rooms
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

        // GameStats
        difficulty = saveData.difficulty;
        skill = saveData.skill;
        currLevel = saveData.currLevel;
        nextLevel = saveData.nextLevel;
        maxStrikes = saveData.maxStrikes;

        // PlayerStats
        playerStrikes = saveData.playerStrikes;
        playerPoints = saveData.playerPoints;

        // Supply Room Data
        supplyRoom_ChecklistComplete = saveData.supplyRoom_ChecklistComplete;
        checklist = saveData.checklist;

        // Medication Room Data
        medRoom_ChecklistComplete = saveData.medRoom_ChecklistComplete;
        playerResponses_MedCart = saveData.playerResponses_MedCart;

        // Room Completion Data
        supplyRoom_Completion = saveData.supplyRoom_Completion;
        medRoom_Completion = saveData.medRoom_Completion;
        skillsRoom_Completion = saveData.skillsRoom_Completion;
    }


    //sets default values
    public void GenerateDefaults()
    {
        // GameStats
        difficulty = null;
        skill = null;
        currLevel = null;
        nextLevel = null;
        maxStrikes = -1;

        // PlayerStats
        playerStrikes = -1;
        playerPoints = -1;

        // Supply Room Data
        supplyRoom_ChecklistComplete = false;
        checklist = new List<GameObject>();

        // Medication Room Data
        medRoom_ChecklistComplete = false;
        playerResponses_MedCart = new List<int> {0,0,0,0};

        // Room Completion Data
        supplyRoom_Completion = false;
        medRoom_Completion = false;
        skillsRoom_Completion = false;
    }
}
