using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialLibrary  {

    private readonly Dictionary<string, BaseMaterial> library = new Dictionary<string, BaseMaterial>()
    {
        {"Dirt", new BaseMaterial
        {
           Name = "Dirt",
           VisualName = "material_dirt"
        } },
    };



    public BaseMaterial GetMaterialByName(string name)
    {
        if (library.ContainsKey(name))
        {
            return library[name].GetUsableCopy();
        }
        return null;
    }


}
