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
        {"Stone Drum", new BaseMaterial
        {
           Name = "Stone Drum",
           VisualName = "material_StoneDrum"
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
        {"Monster Tooth", new BaseMaterial
        {
           Name = "Monster Tooth",
           VisualName = "material_MonsterTooth"
        } },
        {"Iron", new BaseMaterial
        {
           Name = "Iron",
           VisualName = "material_Iron"
        } },
        {"Spices", new BaseMaterial
        {
           Name = "Spices",
           VisualName = "material_Spices"
        } },
        {"Information", new BaseMaterial
        {
           Name = "Information",
           VisualName = "material_Information"
        } },
        {"Gold", new BaseMaterial
        {
           Name = "Gold",
           VisualName = "material_Gold"
        } },
        {"Diamond", new BaseMaterial
        {
           Name = "Diamond",
           VisualName = "material_Diamond"
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
