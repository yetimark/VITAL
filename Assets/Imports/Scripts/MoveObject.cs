using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public GameObject currentObject;
    public Transform objectTransform;
    public float theDistance;
    public bool selected = false;

    private float skipZ = 0.01f;
    private float zoom;
    private Vector3 vector;

	
	void Update ()
    {
        this.currentObject = this.GetComponent<RaycastForward>().currentObject;
        if(this.currentObject != null)
        {
            this.objectTransform = this.currentObject.transform;
        }
        else
        {
            this.objectTransform = null;
        }
        this.theDistance = this.GetComponent<RaycastForward>().theDistance;

        //Input
        this.zoom = Input.GetAxis("Mouse ScrollWheel");

        SelectObject();
        ObjectMove();
	}

    public void SelectObject()
    {
        if (Input.GetMouseButtonDown(0) && this.currentObject != null)      //select button and pointing at an object   //maybe add in thename
        {
            this.selected = !this.selected;
            this.objectTransform.parent = null;     //Orphan maker
        }
    }

    public void ObjectMove()
    {
                        //make sure zoom moves object along local z and not global z    //no that doesnt seem correct

        if (this.selected)
        {
            this.objectTransform.SetParent(this.transform, true);      //was true

            //this.objectTransform.position = 
            this.objectTransform.rotation = this.transform.rotation;        //backwards?

            if(this.zoom != 0 && this.theDistance > 0.5 && this.theDistance < 10)
            {
                //this.vector = new Vector3()
                this.objectTransform.transform.Translate(Vector3.forward * this.zoom);
            }
            else if(this.theDistance <= 0.5)
            {
                this.objectTransform.Translate(Vector3.forward * this.skipZ);
            }
            else if(this.theDistance >= 10)
            {
                this.objectTransform.Translate(Vector3.back * this.skipZ);
            }
        }
    }
}
