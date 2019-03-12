using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxReturn : MonoBehaviour
{
    private Vector3 returnPosition;

	void Start ()
    {
        this.returnPosition = this.gameObject.transform.position;
	}
	
	public void ReturnHome()
    {
        this.gameObject.transform.position = this.returnPosition;
    }
}
