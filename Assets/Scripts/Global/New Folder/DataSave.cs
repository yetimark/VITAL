using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataSave : MonoBehaviour
{
    public string roomName;
    public string difficulty;
    public int playerStrikes;
    public int playerPoints;

    public void SaveData()
    {
        PlayerPrefs.SetString("roomName", roomName);
        PlayerPrefs.SetString("difficulty", difficulty);
        PlayerPrefs.SetInt("playerStrikes", playerStrikes);
        PlayerPrefs.SetInt("playerPoints", playerPoints);
    }
    public void LoadData()
    {

    }

    public void LoadScoreRoom()
    {
        SceneManager.LoadScene("ScoreRoom");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadSupplyRoom()
    {
        SceneManager.LoadScene("SupplyRoom");
    }
    public void LoadMedRoom()
    {
        SceneManager.LoadScene("MedRoom");
    }
}
