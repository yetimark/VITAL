using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSelection : MonoBehaviour
{
    private GameObject gameManager;
    private PlayerData PD;

    private GameObject difficultySelect;
    private GameObject skillSelect;

    public void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        PD = gameManager.GetComponent<PlayerData>();

        difficultySelect = GameObject.FindGameObjectWithTag("DifficultySelection");
        skillSelect = GameObject.FindGameObjectWithTag("SkillSelection");
    }
    public void Start()
    {
        skillSelect.SetActive(true);
        difficultySelect.SetActive(false);
    }

    public void PiccLine()
    {
        PD.skill = "PiccLine";
        Debug.Log(PD.skill + " has been set");

        skillSelect.SetActive(false);
        difficultySelect.SetActive(true);
    }

    public void IVInsertion()
    {
        PD.skill = "IVInsertion";
        Debug.Log(PD.skill + " has been set");

        skillSelect.SetActive(false);
        difficultySelect.SetActive(true);
    }
}
