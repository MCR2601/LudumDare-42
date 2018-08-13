using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialLibrary  {

    private readonly Dictionary<string, BaseMaterial> library = new Dictionary<string, BaseMaterial>()
    {
        {"Dirt", new BaseMaterial
        {
           Name = "Dirt",
           VisualName = "material_Dirt"
        } },
        {"Clay", new BaseMaterial
        {
           Name = "Clay",
           VisualName = "material_Clay"
        } },
        {"Wood", new BaseMaterial
        {
           Name = "Wood",
           VisualName = "material_Wood"
        } },
        {"Paper", new BaseMaterial
        {
           Name = "Paper",
           VisualName = "material_Paper"
        } },
        {"Stone", new BaseMaterial
        {
           Name = "Stone",
           VisualName = "material_Stone"
        } },
        {"Stone drum", new BaseMaterial
        {
           Name = "Stone drum",
           VisualName = "material_Stone drum"
        } },
        {"Water", new BaseMaterial
        {
           Name = "Water",
           VisualName = "material_Water"
        } },
        {"Apple", new BaseMaterial
        {
           Name = "Apple",
           VisualName = "material_Apple"
        } },
        {"Beef", new BaseMaterial
        {
           Name = "Beef",
           VisualName = "material_Beef"
        } },
        {"Bones", new BaseMaterial
        {
           Name = "Bones",
           VisualName = "material_Bones"
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
