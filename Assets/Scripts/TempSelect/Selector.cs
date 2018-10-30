using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selector : MonoBehaviour
{
    public GameObject NamePanel;

    private void Awake()
    {
        this.NamePanel = GameObject.Find("NamePanel");
    }

    private void Start()
    {
        this.NamePanel.SetActive(false);
    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("here yee");
        if(other.gameObject.tag == "Supplies")
        {
            this.NamePanel.SetActive(true);
            GameObject.Find("Name").GetComponent<Text>().text = other.gameObject.name;

            if (Input.GetMouseButtonDown(0))
            {
                //change name color? or should that come from checklist?
                        //perhaps change bool or here for checklist
            }
        }
    }

    private void ChangeColor()
    {

    }
}
