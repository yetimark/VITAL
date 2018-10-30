using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

                //display name on panel for checklist item

public class CopyObjectName : MonoBehaviour
{
    public string copyName;

    private void Awake()
    {
        this.copyName = this.gameObject.name;
    }

    void Start ()
    {
        this.copyName = this.copyName.Substring(0, this.copyName.Length - 1);   //remove last char
        this.transform.GetChild(0).GetComponent<Text>().text = this.copyName;
    }
}
