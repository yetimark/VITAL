using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supplies : MonoBehaviour
{
    private int index = 0;
    private string myName = "";

    public Supplies(int location, string myName)
    {
        this.myName = myName;
    }

}
