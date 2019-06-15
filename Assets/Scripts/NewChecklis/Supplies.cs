using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supplies : MonoBehaviour
{
    private int index = 0;
    private string myName = "";
    private bool imageState = false;

    public Supplies(int index, bool imageState)
    {
        this.index = index;
        this.imageState = imageState;
    }

    //public void SetIndex(int newIndex) { this.index = newIndex }
    //public int GetIndex() { return this.index; }

    //public void SetImageState(bool newImageState) { this.imageState = newImageState; }
    //public bool GetImageState() { return this.imageState; }

}
