using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingLibrary {

    private readonly Dictionary<string, BaseBuilding> library = new Dictionary<string, BaseBuilding>()
    {
        {"Extractor", new BaseBuilding
        {
            Name = "Extractor",
            VisualName = "building_extractor",
            occupying = new Offset[]
            {
                new Offset(0,0)
            }
        } },
        // follow here with other entries
    };

    public BuildingLibrary()
    {

    }

    public BaseBuilding GetBuildingByName(string name)
    {
        if (library.ContainsKey(name))
        {
            return library[name].GetUsableCopy();
        }
        return null;
    }


}
