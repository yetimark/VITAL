using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempNameAdd : MonoBehaviour
{
    //this is for adding on the item name to the ned of its descrioption


	void Start ()
    {
        this.gameObject.GetComponent<Text>().text += this.gameObject.name;
	}
	
}
