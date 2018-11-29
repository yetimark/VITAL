using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperSpawner : MonoBehaviour
{
    public GameObject paper;
    private GameObject fakePaper;

    private Transform paperSpawn;
    private Transform paperTransform;
    public bool once = true;
    public bool only = true;

	void Awake ()
    {
        this.paperTransform = GameObject.FindGameObjectWithTag("PaperTowel").transform;
        this.paperSpawn = this.gameObject.transform;
        this.fakePaper = GameObject.Find("FakePaper");
	}

    private void Start()
    {
        this.fakePaper.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.transform == this.paperTransform)
        {
            Debug.Log("Paper is Falling");
//            Debug.Log("Paper Has Been Torn");
        }

    }
    void Update ()//FIXME# runs immediately
    {
        //if it has been moved, turn gravity on and spawn a new instance of the prefab as well as disabling the if block
		if(this.paperSpawn.position != this.paperTransform.position && this.once)
        {
            Debug.Log("Paper has been Torn");
            this.once = false;
            this.paperTransform.GetComponent<Rigidbody>().useGravity = true;
            this.paperTransform.GetComponent<Rigidbody>().isKinematic = false;
            this.fakePaper.SetActive(true);
            //Instantiate(this.paper, this.paperSpawn);

            //this directly changes a variable in required to place objects on the table
            GameObject.FindGameObjectWithTag("Table").GetComponent<CheckListChecker>().handsDried = true;
        }
	}
}
