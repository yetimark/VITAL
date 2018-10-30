using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMaster : MonoBehaviour
{
    public GameObject namePanel;
    public GameObject infoPanel;
    public GameObject currentObject;
    public bool hiit;
    public bool selected;

	void Awake ()
    {
        this.namePanel = GameObject.Find("NamePanel");
        this.infoPanel = GameObject.Find("InfoPanel");
	}

    void Start()
    {
        this.namePanel.SetActive(false);
        this.infoPanel.SetActive(false);
    }

    void Update ()
    {
        this.hiit = GameObject.Find("Pointer").GetComponent<RaycastForward>().hiit;
        this.selected = GameObject.Find("Pointer").GetComponent<MoveObject>().selected;
        this.currentObject = GameObject.Find("Pointer").GetComponent<RaycastForward>().currentObject;

        if (this.hiit)      //hovering
        {
            this.namePanel.SetActive(true);
            GameObject.Find("NameTag").GetComponent<Text>().text = this.currentObject.name;

            if (this.selected)      //selected
            {
                this.infoPanel.SetActive(true);
                GameObject.Find("InfoBox").GetComponent<Text>().text = GameObject.Find(this.currentObject.name).GetComponent<Text>().text;
            }
            else
            {
                this.infoPanel.SetActive(false);
            }
        }
        else
        {
            this.namePanel.SetActive(false);
        }
    }
}
