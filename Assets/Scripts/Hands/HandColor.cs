using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandColor : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<Renderer>().material.color = new Color32(255, 203, 164, 0); // RGB values of the color. Flesh color is: [255, 203, 164].
    }
}
