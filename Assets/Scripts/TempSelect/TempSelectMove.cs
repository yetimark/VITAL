using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempSelectMove : MonoBehaviour
{

    public int moveSpeed;

    private float translation;

	void Update ()
    {
		if(Input.GetAxis("Horizontal") != 0)
        {
            this.translation = Input.GetAxis("Horizontal") * this.moveSpeed * Time.deltaTime;
            this.transform.Translate(0, 0, this.translation);
        }

        if(Input.GetAxis("Vertical") != 0)
        {
            this.translation = Input.GetAxis("Vertical") * this.moveSpeed * Time.deltaTime;
            this.transform.Translate(0, this.translation, 0);
        }
	}
}
