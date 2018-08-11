using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// materials for processing
/// </summary>
public class BaseMaterial  {
    
    public string Name;

    public string VisualName;


    public GameObject GameObject;
    public SimpleCords position;

    protected bool usable = false;

    public BaseMaterial()
    {

    }

    public BaseMaterial GetUsableCopy()
    {
        return usable ? this : new BaseMaterial() { usable = true, Name = Name, VisualName = VisualName };
    }

    public void Place(SimpleCords atLocation)
    {
        if (usable)
        {
            GameObject obj = Object.Instantiate(ResourceLibrary.GetPrefabByName(VisualName));
            obj.transform.position = new Vector3(atLocation.x,atLocation.y+0.5f,atLocation.z);
            GameObject = obj;
        }
        else
        {
            throw new System.Exception("Used Unusable Material!");
        }
    }

}
