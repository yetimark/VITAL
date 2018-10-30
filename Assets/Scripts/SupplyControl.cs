using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyControl : MonoBehaviour
{
    public Transform supplies;
    public GameObject emptyLocations;
    public Transform spawnLocation;
    public List<Transform> locations;
    //private int locationNumber = 0;
    //this.transform.GetChildCount;

    private void Awake()
    {
        this.supplies = GameObject.Find("Supplies").transform;
        this.emptyLocations = GameObject.Find("SupplyLocations");
        this.spawnLocation = this.supplies;
        AddLocations();
        RandomizeSupplies();
    }

    void Start ()
    {
        //AddLocations();
        //RandomizeSupplies();
	}

    void AddLocations()     //adds empty gameobjects to a list for supply placement
    {
        for(int i = 0; i < this.emptyLocations.transform.childCount; i++)
        {
            this.locations.Add(this.emptyLocations.transform.GetChild(i));
        }
    }

    void RandomizeSupplies()
    {
        //lists are modefiable      so when item is used remove from list
        for (int i = this.supplies.childCount - 1; i > 0; i--)
        {
            this.spawnLocation = this.locations[Random.Range(0, i)];
            this.supplies.GetChild(i).transform.position = this.spawnLocation.position;
            this.locations.Remove(this.spawnLocation);
        }
    }
}
