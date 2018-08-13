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
            Orientatation = rotation;

            for (int i = 0; i < occupying.Length; i++)
            {
                occupying[i] = occupying[i].Rotate(Orientatation);
            }

            GameObject obj = Object.Instantiate(ResourceLibrary.GetPrefabByName(VisualName));
            obj.transform.position = atLocation;
            obj.transform.rotation = Quaternion.Euler(0,90 * (rotation+1), 0);
            GameObject = obj;
            GameObject t = Object.Instantiate(ResourceLibrary.GetPrefabByName("prop_Timer"));
            t.transform.position = atLocation;
            Clock = t.GetComponentInChildren<lookAtCamera>();
            Timer = t;

            if (Input.enabled)
            {
                Clock.SetTimer(-1);
            }
            else
            {
                Clock.SetTimer(Output.DeliverTimer);
            }
            // TODO: Rotation
            // TODO: Place Object with everything
        }
        else
        {
            throw new System.Exception("Used Unusable Building!");
        }
    }





}
