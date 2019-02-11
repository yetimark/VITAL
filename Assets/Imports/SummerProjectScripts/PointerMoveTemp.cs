using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerMoveTemp : MonoBehaviour // this script should be removed when pointer is added to a hand controller.. this serves as an artificial 3Degrees of motion
{
    private float moveSpeed = 5f;
    private float yaw;
    private float pitch;
    private float roll;

	void Update ()
    {
        this.yaw = Input.GetAxis("Horizontal") * this.moveSpeed;
        this.pitch = Input.GetAxis("Vertical") * this.moveSpeed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.roll = 1f * this.moveSpeed;
        }
        else
        {
            this.roll = 0f;
        }


        this.transform.Rotate(Vector3.up * this.yaw);
        this.transform.Rotate(Vector3.left * this.pitch);
        this.transform.Rotate(Vector3.forward * this.roll);
	}
}
