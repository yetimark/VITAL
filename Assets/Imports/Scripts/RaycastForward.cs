using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastForward : MonoBehaviour
{
    public GameObject currentObject;
    public Transform glow;
    public float theDistance;
    public bool hiit = false;

    public string theName = "";
    private Vector3 forward;
	
	void Update ()
    {
        RaycastHit hit;

        //Direction for raycast
        this.forward = this.transform.TransformDirection(Vector3.forward) * 10;
        //Debug.DrawRay(this.transform.position, this.forward, Color.cyan);

        if (Physics.Raycast(this.transform.position, this.forward, out hit))
        {
            Debug.Log(hit.collider.name);
            if(this.theName == null)
            {
                this.theName = hit.collider.name;
                Debug.Log(this.theName);
                this.hiit = hit.collider;
                this.theDistance = hit.distance;
                this.currentObject = hit.collider.gameObject;

                if (GameObject.Find("Glow(Clone)") == null)
                {
                    StartGlowing();
                }
            }
        }
        else
        {
            this.currentObject = null;
            this.theName = null;
            Destroy(GameObject.Find("Glow(Clone)"));
            this.hiit = false;          
        }
    }

    public void StartGlowing()
    {      
        Instantiate(this.glow, currentObject.transform.position, Quaternion.identity, this.currentObject.transform);//Instantiate(object, position, rotation, parent)
    }
}
