using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandColor : MonoBehaviour
{
    private Color32 handColor; //RGB values of the color. Flesh color is: [##, ##, ##].
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = handColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
