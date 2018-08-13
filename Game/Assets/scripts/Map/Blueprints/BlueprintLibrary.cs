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
        {"Tree Farm", new BaseBlueprint
        {
            Name = "Tree Farm",
            MaterialRequirements = new List<MaterialOffset>
            {
                new MaterialOffset()
                {
                   MaterialName = "Clay",
                   Offset = new Offset(0,0)
                },
                new MaterialOffset()
                {
                   MaterialName = "Clay",
                   Offset = new Offset(1,0)
                }
            }
        } },
        {"Paper Factory", new BaseBlueprint
        {
            Name = "Paper Factory",
            MaterialRequirements = new List<MaterialOffset>
            {
                new MaterialOffset()
                {
                   MaterialName = "Wood",
                   Offset = new Offset(0,0)
                },
                new MaterialOffset()
                {
                   MaterialName = "Clay",
                   Offset = new Offset(1,0)
                }
            }
        } },
        {"Furnace", new BaseBlueprint
        {
            Name = "Furnace",
            MaterialRequirements = new List<MaterialOffset>
            {
                new MaterialOffset()
                {
                   MaterialName = "Wood",
                   Offset = new Offset(0,0)
                }
                ,
                new MaterialOffset()
                {
                    MaterialName = "Stone",
                    Offset = new Offset(0,-1)
                }
                ,
                new MaterialOffset()
                {
                    MaterialName = "Stone",
                    Offset = new Offset(1,0)
                }
            }
        } },
        {"Quarry", new BaseBlueprint
        {
            Name = "Quarry",
            MaterialRequirements = new List<MaterialOffset>
            {
                new MaterialOffset()
                {
                   MaterialName = "Clay",
                   Offset = new Offset(0,0)
                }
                ,
                new MaterialOffset()
                {
                    MaterialName = "Wood",
                    Offset = new Offset(1,0)
                }
                ,
                new MaterialOffset()
                {
                    MaterialName = "Wood",
                    Offset = new Offset(-1,0)
                }
            }
        } },
        {"Masonry", new BaseBlueprint
        {
            Name = "Masonry",
            MaterialRequirements = new List<MaterialOffset>
            {
                new MaterialOffset()
                {
                   MaterialName = "Iron",
                   Offset = new Offset(0,0)
                }
                ,
                new MaterialOffset()
                {
                    MaterialName = "Stone",
                    Offset = new Offset(1,0)
                }
                ,
                new MaterialOffset()
                {
                    MaterialName = "Stone",
                    Offset = new Offset(-1,0)
                }
            }
        } },
        {"Well", new BaseBlueprint
        {
            Name = "Well",
            MaterialRequirements = new List<MaterialOffset>
            {
                new MaterialOffset()
                {
                   MaterialName = "Stone drum",
                   Offset = new Offset(0,0)
                }
                ,
                new MaterialOffset()
                {
                    MaterialName = "Clay",
                    Offset = new Offset(0,1)
                }
                ,
                new MaterialOffset()
                {
                    MaterialName = "Clay",
                    Offset = new Offset(0,-1)
                }
                ,
                new MaterialOffset()
                {
                    MaterialName = "Wood",
                    Offset = new Offset(1,0)
                }
                ,
                new MaterialOffset()
                {
                    MaterialName = "Wood",
                    Offset = new Offset(-1,0)
                }
            }
        } },
        {"Cow Farm", new BaseBlueprint
        {
            Name = "Cow Farm",
            MaterialRequirements = new List<MaterialOffset>
            {
                new MaterialOffset()
                {
                   MaterialName = "Wood",
                   Offset = new Offset(0,0)
                }
                ,
                new MaterialOffset()
                {
                    MaterialName = "Wood",
                    Offset = new Offset(1,0)
                }
                ,
                new MaterialOffset()
                {
                    MaterialName = "Wood",
                    Offset = new Offset(-1,0)
                }
                ,
                new MaterialOffset()
                {
                    MaterialName = "Apple",
                    Offset = new Offset(-1,-1)
                }
                ,
                new MaterialOffset()
                {
                    MaterialName = "Clay",
                    Offset = new Offset(0,-1)
                }
                ,
                new MaterialOffset()
                {
                    MaterialName = "Water",
                    Offset = new Offset(1,-1)
                }
            }
        } },
        {"Monster Hunter", new BaseBlueprint
        {
            Name = "Monster Hunter",
            MaterialRequirements = new List<MaterialOffset>
            {
                new MaterialOffset()
                {
                   MaterialName = "Wood",
                   Offset = new Offset(0,0)
                }
                ,
                new MaterialOffset()
                {
                    MaterialName = "Beef",
                    Offset = new Offset(1,0)
                }
                ,
                new MaterialOffset()
                {
                    MaterialName = "Iron",
                    Offset = new Offset(0,-1)
                }
                ,
                new MaterialOffset()
                {
                    MaterialName = "Water",
                    Offset = new Offset(1,-1)
                }
            }
        } },
        {"Dog Hut", new BaseBlueprint
        {
            Name = "Dog Hut",
            MaterialRequirements = new List<MaterialOffset>
            {
                new MaterialOffset()
                {
                   MaterialName = "Wood",
                   Offset = new Offset(0,0)
                },
                new MaterialOffset()
                {
                   MaterialName = "Bones",
                   Offset = new Offset(1,0)
                }
            }
        } },
        {"Marketplace", new BaseBlueprint
        {
            Name = "Marketplace",
            MaterialRequirements = new List<MaterialOffset>
            {
                new MaterialOffset()
                {
                   MaterialName = "Wood",
                   Offset = new Offset(0,0)
                }
                ,
                new MaterialOffset()
                {
                    MaterialName = "Stone",
                    Offset = new Offset(1,0)
                }
                ,
                new MaterialOffset()
                {
                    MaterialName = "Stone",
                    Offset = new Offset(-1,0)
                }
                ,
                new MaterialOffset()
                {
                    MaterialName = "Apple",
                    Offset = new Offset(-1,1)
                }
                ,
                new MaterialOffset()
                {
                    MaterialName = "Gold",
                    Offset = new Offset(0,-1)
                }
            }
        } },
        {"Tavern", new BaseBlueprint
        {
            Name = "Tavern",
            MaterialRequirements = new List<MaterialOffset>
            {
                new MaterialOffset()
                {
                   MaterialName = "Stone",
                   Offset = new Offset(0,0)
                }
                ,
                new MaterialOffset()
                {
                    MaterialName = "Beef",
                    Offset = new Offset(1,0)
                }
                ,
                new MaterialOffset()
                {
                    MaterialName = "Wood",
                    Offset = new Offset(-1,0)
                }
                ,
                new MaterialOffset()
                {
                    MaterialName = "Paper",
                    Offset = new Offset(-1,1)
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
