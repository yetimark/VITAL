using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxReturn : MonoBehaviour
{
    public Vector3 returnPosition;

	void Start ()
    {
        this.returnPosition = this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
