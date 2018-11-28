using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapScript : MonoBehaviour {
    public GameObject handWashStation;

	// Use this for initialization
	void Awake () {
		
	}

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hands have been washed");
            GameObject.FindGameObjectWithTag("Table").GetComponent<CheckListChecker>().handsDried = true;
        }
    }
}
