using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperSpawner : MonoBehaviour
{
    public GameObject paper;

    private Transform startPosition;
    private Vector3 sPosition;
    public bool once = true;

	void Awake ()
    {
        this.sPosition = this.gameObject.transform.position;
        this.startPosition = GameObject.Find("StartPosition").transform;
	}
	
	void Update ()//FIXME# runs immediately
    {
        //if it has been moved, turn gravity on and spawn a new instance of the prefab as well as disabling the if block
		if(this.gameObject.transform.position != this.sPosition && this.once)
        {
            this.once = false;
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            Instantiate(this.paper, this.startPosition);

            //this directly changes a variable in required to place objects on the table
            GameObject.FindGameObjectWithTag("Table").GetComponent<CheckListChecker>().handsDried = true;
        }
	}
}
