using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintLibrary  {
    
    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    // IMPORTANT!!!!!!!!!!!!!!
    // every Offset a building occupies has to be used for the recipie.
    // it is ok to not occupy all tiles
    // we currently DO NOT SUPPORT empty Tiles

    private readonly Dictionary<string, BaseBlueprint> library = new Dictionary<string, BaseBlueprint>()
    {
        {"Extractor", new BaseBlueprint
        {
            Name = "Extractor",
            MaterialRequirements = new List<MaterialOffset>
            {
                new MaterialOffset()
                {
                   MaterialName = "Dirt",
                   Offset = new Offset(0,0)
                }
            }
        } },
    };

    public BlueprintLibrary()
    {

    }


    public BaseBlueprint GetBlueprintByName(string name)
    {
        if (library.ContainsKey(name))
        {
            return library[name];
        }
        return null;
    }

    public List<BaseBlueprint> GetAllBlueprints()
    {
        List<BaseBlueprint> list = new List<BaseBlueprint>();

        foreach (var item in library)
        {
            list.Add(item.Value);
        }
        return list;
    }


}
