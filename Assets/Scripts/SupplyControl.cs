using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyControl : MonoBehaviour
{
    public Transform supplies;
    public GameObject emptyLocations;
    public Transform spawnLocation;
    public List<Transform> locations;

    private void Awake()
    {
        supplies = GameObject.Find("Supplies").transform;
        emptyLocations = GameObject.Find("SupplyLocations");
        spawnLocation = supplies;
        AddLocations();
        RandomizeSupplies();
    }

    void AddLocations()     //adds empty gameobjects to a list for supply placement
    {
        for(int i = 0; i < emptyLocations.transform.childCount; i++)
        {
            locations.Add(emptyLocations.transform.GetChild(i));
        }
    }

    void RandomizeSupplies()
    {
        //lists are modefiable      so when item is used remove from list
        for (int i = supplies.childCount - 1; i > 0; i--)
        {
            spawnLocation = locations[Random.Range(0, i)];
            supplies.GetChild(i).transform.position = spawnLocation.position;
            locations.Remove(spawnLocation);
        }
    }
}
