using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{
    //public GameObject cursor;
    public List<Transform> tableSpots;
    public int tableLength = 0;
    private GameObject namePanel;
    private bool selected = false;

    private void Awake()
    {
        this.namePanel = GameObject.Find("NamePanel");

        for (int i = GameObject.Find("TableLocations").transform.childCount - 1; i >= 0; i--)
        {
            this.tableSpots.Add(GameObject.Find("TableLocations").transform.GetChild(i));
            this.tableLength++;
            Debug.Log(this.tableLength);
        }
    }

    void Start ()
    {
        this.namePanel.SetActive(false);
	}
	

	void Update ()
    {
        //Debug.Log(Input.mousePosition);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider.gameObject.tag == "Supplies")
            {
                this.namePanel.SetActive(true);
                Debug.Log("rayinfo " + hit.collider.gameObject.tag);
                GameObject.Find("Name").GetComponent<Text>().text = hit.collider.gameObject.name;
                GameObject.Find("Name").GetComponent<Text>().color = Color.black;

                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("clicked");
                    this.selected = !this.selected;
                    //check and change name color
                }

                if (this.selected)
                {
                    this.selected = false;
                    for(int i = 0; i < 15; i++)
                    {
                        hit.collider.gameObject.transform.position = this.tableSpots[i].position;

                    }
                }
            }
        }
        else
        {
            this.namePanel.SetActive(false);
        }
	}
}
