using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ========= Item ==========
 * - Each Supply Item is assigned an ID and a name
 * 
 * ~Written by Austin Winkler
 * ======================================*/

public class Item : MonoBehaviour
{
    public GameObject item;
    public int myId;
    private string itemName;

    public void Awake() // An item's name is pulled directly off of the gameObject within Unity's editor
    {                   
        itemName = item.name;
    }

    public string getItemName() { return itemName; }
}
