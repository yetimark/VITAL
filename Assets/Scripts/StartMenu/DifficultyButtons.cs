using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyButtons : MonoBehaviour
{
    public GameObject player;
    public GameObject spawn;

    private GameObject lobbyMusic;

    private GameObject gameManager;
    private PlayerData PD;

    public void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        lobbyMusic = GameObject.FindGameObjectWithTag("LobbyMusic");
        PD = gameManager.GetComponent<PlayerData>();
    }
    public void Start()
    {
        lobbyMusic.GetComponent<AudioSource>().Play();
        Debug.Log("LobbyMusic");
    }

    public void EasyButton()
    {
        Debug.Log("Easy Button pressed");
        lobbyMusic.GetComponent<AudioSource>().Stop();

        PD.difficulty = "Easy";
        PD.skill = "PiccLine";
        Debug.Log("Difficulty is: " + PD.difficulty);
        PD.Save();
        SceneManager.LoadScene("SupplyRoom"); 
    }
    public void MediumButton()
    {
        Debug.Log("Medium Button pressed");
        lobbyMusic.GetComponent<AudioSource>().Stop();

        PD.difficulty = "Medium";
        PD.skill = "PiccLine";
        PD.maxStrikes = 4;
        PD.Save();
        SceneManager.LoadScene("SupplyRoom");
    }
    public void HardButton()
    {
        Debug.Log("Hard Button pressed");
        lobbyMusic.GetComponent<AudioSource>().Stop();

        PD.difficulty = "Hard";
        PD.skill = "PiccLine";
        PD.maxStrikes = 2;
        PD.Save();
        SceneManager.LoadScene("SupplyRoom");
    }
}
