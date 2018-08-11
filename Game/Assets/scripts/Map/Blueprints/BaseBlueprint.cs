using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBlueprint  {

    public string Name;

    public MaterialOffset[] MaterialRequirements;
    

    public BaseBlueprint()
    {

    }

    public List<string> GetMaterialRequirements()
    {
        List<string> materials = new List<string>();
        foreach (var item in MaterialRequirements)
        {
            if (!materials.Contains(item.MaterialName))
            {
                materials.Add(item.MaterialName);
            }
        }
        return materials;
    }


}
