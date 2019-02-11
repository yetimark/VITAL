using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//for saving characters over scenes.. hoping could be included for multiplayer but 
//will work for solo at least

public class CharacterManager : MonoBehaviour
{

    public static CharacterManager instance;

    [SerializeField]
    private GameObject[] characters;

    [HideInInspector]
    public int selectedCharacter;

    // Use this for initialization
    void Awake ()
    {
        MakeSingleton();
	}

    //
    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
