using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceLibrary {
    
    /// <summary>
    /// The Prefabs are stored in a special format, starting with the type and then '_' with the name 
    /// </summary>
    /// <example>
    /// material_dirt
    /// prop_pallet
    /// building_well
    /// </example>
    private readonly static Dictionary<string, string> library; // name for internal/name for external

    static ResourceLibrary()
    {
         library = LoadAllResources();
    }

    private static Dictionary<string, string> LoadAllResources()
    {
        GameObject[] Materials =  Resources.LoadAll<GameObject>("materials");
        GameObject[] Buildings = Resources.LoadAll<GameObject>("buildings");
        GameObject[] Props = Resources.LoadAll<GameObject>("props");

        Dictionary<string, string> temp = new Dictionary<string, string>();

        foreach (var item in Materials)
        {
            temp.Add("material_" + item.name, "materials/"+item.name);
        }
        foreach (var item in Buildings)
        {
            temp.Add("building_" + item.name, "buildings/"+item.name);
        }
        foreach (var item in Props)
        {
            temp.Add("prop_" + item.name, "props/"+item.name);
        }
        return temp;
    }

    public static GameObject GetPrefabByName(string Name)
    {
        return Resources.Load<GameObject>(library[Name]);
    }


}
