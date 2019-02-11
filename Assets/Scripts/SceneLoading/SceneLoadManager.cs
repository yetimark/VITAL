using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{

    public static SceneLoadManager instance;
    public string levelName;//public or private?

    [SerializeField]
    private GameObject loadingScreen;

    //calls the main scene we have been working on
    public void LoadEscapeRoom()
    {
        SceneManager.LoadScene("SupplyEscape");
    }
	
    void MakeSingleton()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }


    //for a generic loading1
    public void LoadLevel(string name)
    {
        levelName = name;
        StartCoroutine(LoadLevelWithName());
    }

    //loading screen delay time
    IEnumerator LoadLevelWithName()
    {
        loadingScreen.SetActive(true);
        SceneManager.LoadScene(levelName);
        yield return new WaitForSeconds(3f);
        loadingScreen.SetActive(false);
    }
}
