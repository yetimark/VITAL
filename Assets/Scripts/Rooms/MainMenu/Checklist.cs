using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checklist : MonoBehaviour
{
    private GameObject gameManager;
    private PlayerData PD;

    // Full list of objects 
    public GameObject dressingChangeKit;
    public GameObject faceMask;
    public GameObject securementDevice;
    public GameObject sterile4x4;
    public GameObject sterileDrape;
    public GameObject sterileGloves;
    public GameObject tegaderm;
    public GameObject alcoholWipes;
    public GameObject biopatch;
    public GameObject chux;
    public GameObject cleanGloves;

    public GameObject secondaryIVTubing;
    public GameObject ivExtensionSet;
    public GameObject insulinSyringe;
    public GameObject carpujectCartridge;
    public GameObject syringe_3cc;
    public GameObject oneInchNeedle_23G;
    public GameObject ivCatheter;
    public GameObject ivStartKit;
    public GameObject foleyCatheter;
    public GameObject incentiveSpirometer;
    public GameObject primaryIVSet;

    public void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        PD = gameManager.GetComponent<PlayerData>();
        if (PD.skill == "PiccLine") { CreateList_PiccLine(); }

        GameObject[] checklist = new GameObject[] { dressingChangeKit, faceMask, securementDevice, sterile4x4, sterileDrape,
                                                sterileGloves, tegaderm, alcoholWipes, biopatch, chux, cleanGloves,
                                                secondaryIVTubing, ivExtensionSet, insulinSyringe, carpujectCartridge,
                                                syringe_3cc, oneInchNeedle_23G, ivCatheter, ivStartKit, foleyCatheter,
                                                incentiveSpirometer, primaryIVSet};
    }

    public void CreateList_PiccLine() // Total 11 Items
    {
        // Assign all items to this skill a tag (numbered from 0 to whatever the max is).
        // MAKE SURE the max number of tag has already been created in the Tag Manager within the Unity Editor.

        dressingChangeKit.tag = "0";
        faceMask.tag = "1";
        securementDevice.tag = "2";
        sterile4x4.tag = "3";
        sterileDrape.tag = "4";
        sterileGloves.tag = "5";
        tegaderm.tag = "6";
        alcoholWipes.tag = "7";
        biopatch.tag = "8";
        chux.tag = "9";
        cleanGloves.tag = "10";

        // Set all other items which don't apply (to this skill) to "-1"
        secondaryIVTubing.tag = "-1";
        ivExtensionSet.tag = "-1";
        insulinSyringe.tag = "-1";
        carpujectCartridge.tag = "-1";
        syringe_3cc.tag = "-1";
        oneInchNeedle_23G.tag = "-1";
        ivCatheter.tag = "-1";
        ivStartKit.tag = "-1";
        foleyCatheter.tag = "-1";
        incentiveSpirometer.tag = "-1";
        primaryIVSet.tag = "-1";
    }

    /* FULL LIST OF ITEMS
       
        dressingChangeKit
        faceMask
        securementDevice
        sterile4x4
        sterileDrape
        sterileGloves
        tegaderm
        alcoholWipes
        biopatch
        chux
        cleanGloves

        secondaryIVTubing
        ivExtensionSet
        insulinSyringe
        carpujectCartridge
        syringe_3cc
        oneInchNeedle_23G
        ivCatheter
        ivStartKit
        foleyCatheter
        incentiveSpirometer
        primaryIVSet
        
     */
}

