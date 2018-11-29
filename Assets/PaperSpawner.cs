using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperSpawner : MonoBehaviour
{
    public GameObject paper;
    private GameObject fakePaper;

    private Transform paperSpawn;
    private Transform paperTransform;
    //public bool once = true;
    public bool only = false;

	void Awake ()
    {
        //this.paperTransform = GameObject.FindGameObjectWithTag("PaperTowel").transform;
        this.paperSpawn = this.gameObject.transform;
        this.fakePaper = GameObject.Find("FakePaper");
	}

    private void Start()
    {
        this.fakePaper.SetActive(true);     //set to false normally
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
        if (only)
        {
            this.only = false;
            this.paperTransform.GetComponent<Rigidbody>().useGravity = true;
            this.paperTransform.GetComponent<Rigidbody>().isKinematic = false;
            this.fakePaper.SetActive(true);
            GameObject.FindGameObjectWithTag("Table").GetComponent<CheckListChecker>().handsDried = true;
            Debug.Log("Paper has been torn");
        }

    }
}
