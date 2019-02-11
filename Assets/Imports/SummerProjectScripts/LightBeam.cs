using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeam : MonoBehaviour
{
    public GameObject currentObject;//should be able to manipulate object position from this
    public float theDistance;

    private Vector3 start;
    private Vector3 end;
    private float width = 0.01f;
    private LineRenderer beam;

	void Awake ()
    {
        //color and width
        this.beam = this.GetComponent<LineRenderer>();
        this.beam.startWidth = width;
        this.beam.endWidth = width;
	}

    void Update()       //bug #beam is in local space but ray is in world space. Beam is rotating 2x as much as ray
    {
        this.currentObject = this.GetComponent<RaycastForward>().currentObject;
        this.theDistance = this.GetComponent<RaycastForward>().theDistance;

        this.start = Vector3.zero;
        this.beam.SetPosition(0, this.start);

        if (this.currentObject != null) //if something in is in the way, go to that position, otherwise be 10

        {
            this.end = new Vector3(0, 0, this.theDistance);
            this.beam.SetPosition(1, this.end);
        }
        else
        {
            this.end = new Vector3(0, 0, 10) + this.start;      
            this.beam.SetPosition(1, this.end);
        }
    }
}
