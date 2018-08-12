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

    public MaterialInput Input;

    public MaterialOutput Output;

    public SimpleCords CenterLocation;

    public GameObject Timer;

    public lookAtCamera Clock;

    public BaseBuilding()
    {

    }

    //TODO: make builder for this Class
    public BaseBuilding GetUsableCopy()
    {
        BaseBuilding bb = new BaseBuilding
        {
            Input = Input,
            Output = Output,
            occupying = occupying,
            usable = true,
            Name = Name,
            VisualName = VisualName
        };

        return bb;
    }

    public void PlaceWithOrientation(int rotation, SimpleCords atLocation)
    {
        if (usable)
        {
            GameObject obj = Object.Instantiate(ResourceLibrary.GetPrefabByName(VisualName));
            obj.transform.position = atLocation;
            GameObject = obj;
            GameObject t = Object.Instantiate(ResourceLibrary.GetPrefabByName("prop_Timer"));
            t.transform.position = atLocation;
            Clock = t.GetComponentInChildren<lookAtCamera>();
            Timer = t;

            Clock.SetTimer(Output.DeliverTimer);

            // TODO: Rotation
            // TODO: Place Object with everything
        }
        else
        {
            throw new System.Exception("Used Unusable Building!");
        }
    }





}
