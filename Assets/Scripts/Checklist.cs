using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checklist : MonoBehaviour
{
    private GameObject txtboxAdjuster;
    private int index = 0;

    public void Awake()
    {
        txtboxAdjuster = GameObject.Find("checkspot_" + index);
    }
}
