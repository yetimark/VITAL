using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWarning : MonoBehaviour
{
    public GameObject warningPanel;
    public GameObject message;
    public GameObject warning;

    public string strikeMessage;
    public Dictionary<string, string> warningsBook = new Dictionary<string, string>();

    private void Awake()
    {
        this.warningPanel = GameObject.Find("WarningPanel");
        this.message = GameObject.Find("Message");
        this.warning = GameObject.Find("Warning");
    }

    void Start ()
    {
        this.warningPanel.SetActive(false);

        this.warningsBook.Add("GameOver", "You have made too many errors. Please exit the simulation and practice or try again.");
        this.warningsBook.Add("Strike", "You have made an error. Proceed with caution. Once you have made to many errors you will strike out.");
        this.warningsBook.Add("IncorrectOrder", "You must wash your hand correctly.");

        this.warningsBook.Add("SoapHands", "You must put soap on your hands to make them clean!");
        this.warningsBook.Add("WashHands", "You forgot to wash your hands!");
        this.warningsBook.Add("DryHands", "You must dry your hands before proceeding!");
	}
	
    public void WarningMessage(string messageName)
    {
        this.warningPanel.SetActive(true);
        this.warning.GetComponent<Text>().text = messageName;
        this.message.GetComponent<Text>().text = this.warningsBook[messageName];
        StartCoroutine(CloseAfterWarning(5f));
    }

    IEnumerator CloseAfterWarning(float sec)
    {
        yield return new WaitForSeconds(sec);
    }

	void Update ()
    {
        if (Input.GetKey("b"))
        {
            this.warningPanel.SetActive(false);
        }
	}
}
