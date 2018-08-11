using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuilding {

    public string Name;
    // the name of the Prefab
    public string VisualName;
    public GameObject GameObject;

    public Offset[] occupying;
    /// <summary>
    /// How the Object is turned by 90°
    /// </summary>
    private int Orientatation;

    protected bool usable = false;






    public BaseBuilding()
    {

    }

    //TODO: make builder for this Class
    public BaseBuilding GetUsableCopy()
    {
        BaseBuilding bb = new BaseBuilding
        {
            usable = true,
            Name = Name,
            VisualName = VisualName
        };

        return bb;
    }







}
