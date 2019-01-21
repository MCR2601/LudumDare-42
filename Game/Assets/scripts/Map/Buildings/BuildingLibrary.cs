using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingLibrary {

    private readonly Dictionary<string, BaseBuilding> library = new Dictionary<string, BaseBuilding>()
    {
        {"Extractor", new BaseBuilding
        {
            Name = "Extractor",
            VisualName = "building_Extractor",
            occupying = new Offset[]
            {
                new Offset(0,0)
            },
            Input = new MaterialInput(),
            Output = new MaterialOutput()
            {
                enabled = true,
                HasToConsume = false,
                DeliverTimer = 3,
                DeliveryLocation = new Offset(0,1),
                MaterialName = "Clay"
            }
        } },
        {"Tree Farm", new BaseBuilding
        {
            Name = "Tree Farm",
            VisualName = "building_Tree Farm",
            occupying = new Offset[]
            {
                new Offset(0,0),
                new Offset(1,0)
            },
            Input = new MaterialInput(),
            Output = new MaterialOutput()
            {
                enabled = true,
                HasToConsume = false,
                DeliverTimer = 3,
                DeliveryLocation = new Offset(0,1),
                MaterialName = "Wood"
            }
        } },
        {"Paper Factory", new BaseBuilding
        {
            Name = "Paper Factory",
            VisualName = "building_Paper Factory",
            occupying = new Offset[]
            {
                new Offset(0,0),
                new Offset(1,0)
            },
            Input = new MaterialInput(),
            Output = new MaterialOutput()
            {
                enabled = true,
                HasToConsume = false,
                DeliverTimer = 3,
                DeliveryLocation = new Offset(0,1),
                MaterialName = "Paper"
            }
        } },
        {"Furnace", new BaseBuilding
        {
            Name = "Furnace",
            VisualName = "building_Furnace",
            occupying = new Offset[]
            {
                new Offset(0,0),
                new Offset(0,-1),
                new Offset(1,0)
            },
            Input = new MaterialInput(),
            Output = new MaterialOutput()
            {
                enabled = true,
                HasToConsume = false,
                DeliverTimer = 3,
                DeliveryLocation = new Offset(0,1),
                MaterialName = "Dirt"
            }
        } },
        {"Quarry", new BaseBuilding
        {
            Name = "Quarry",
            VisualName = "building_Quarry",
            occupying = new Offset[]
            {
                new Offset(0,0),
                new Offset(-1,0),
                new Offset(1,0)
            },
            Input = new MaterialInput(),
            Output = new MaterialOutput()
            {
                enabled = true,
                HasToConsume = false,
                DeliverTimer = 3,
                DeliveryLocation = new Offset(0,1),
                MaterialName = "Stone"
            }
        } },
        {"Masonry", new BaseBuilding
        {
            Name = "Masonry",
            VisualName = "building_Masonry",
            occupying = new Offset[]
            {
                new Offset(0,0),
                new Offset(2,0),
                new Offset(1,0)
            },
            Input = new MaterialInput(),
            Output = new MaterialOutput()
            {
                enabled = true,
                HasToConsume = false,
                DeliverTimer = 3,
                DeliveryLocation = new Offset(1,1),
                MaterialName = "Stone Drum"
            }
        } },
        {"Well", new BaseBuilding
        {
            Name = "Well",
            VisualName = "building_Well",
            occupying = new Offset[]
            {
                new Offset(0,0),
                new Offset(-1,0),
                new Offset(1,0),
                new Offset(0,-1),
                new Offset(0,1)
            },
            Input = new MaterialInput(),
            Output = new MaterialOutput()
            {
                enabled = true,
                HasToConsume = false,
                DeliverTimer = 3,
                DeliveryLocation = new Offset(1,1),
                MaterialName = "Water"
            }
        } },
        {"Cow Farm", new BaseBuilding
        {
            Name = "Cow Farm",
            VisualName = "building_Cow Farm",
            occupying = new Offset[]
            {
                new Offset(0,0),
                new Offset(-1,0),
                new Offset(1,0),
                new Offset(0,-1),
                new Offset(-1,-1),
                new Offset(1,-1)
            },
            Input = new MaterialInput(),
            Output = new MaterialOutput()
            {
                enabled = true,
                HasToConsume = false,
                DeliverTimer = 3,
                DeliveryLocation = new Offset(0,1),
                MaterialName = "Beef"
            }
        } },
        {"Monster Hunter", new BaseBuilding
        {
            Name = "Monster Hunter",
            VisualName = "building_Monster Hunter",
            occupying = new Offset[]
            {
                new Offset(0,0),
                new Offset(1,0),
                new Offset(0,-1),
                new Offset(1,-1),
            },
            Input = new MaterialInput(),
            Output = new MaterialOutput()
            {
                enabled = true,
                HasToConsume = false,
                DeliverTimer = 3,
                DeliveryLocation = new Offset(0,1),
                MaterialName = "Bones"
            }
        } },
        {"Dog Hut", new BaseBuilding
        {
            Name = "Dog Hut",
            VisualName = "building_Dog Hut",
            occupying = new Offset[]
            {
                new Offset(0,0),
                new Offset(1,0)
            },
            Input = new MaterialInput(),
            Output = new MaterialOutput()
            {
                enabled = true,
                HasToConsume = false,
                DeliverTimer = 3,
                DeliveryLocation = new Offset(0,1),
                MaterialName = "Monster Tooth"
            }
        } },
        {"Marketplace", new BaseBuilding
        {
            Name = "Marketplace",
            VisualName = "building_Marketplace",
            occupying = new Offset[]
            {
                new Offset(0,0),
                new Offset(1,0),
                new Offset(1,1),
                new Offset(0,1),
                new Offset(1,-1)
            },
            Input = new MaterialInput(),
            Output = new MaterialOutput()
            {
                enabled = true,
                HasToConsume = false,
                DeliverTimer = 3,
                DeliveryLocation = new Offset(0,-1),
                MaterialName = "Spices"
            }
        } },
        {"Tavern", new BaseBuilding
        {
            Name = "Tavern",
            VisualName = "building_Tavern",
            occupying = new Offset[]
            {
                new Offset(0,0),
                new Offset(-1,0),
                new Offset(1,0),
                new Offset(-1,-1)
            },
            Input = new MaterialInput(),
            Output = new MaterialOutput()
            {
                enabled = true,
                HasToConsume = false,
                DeliverTimer = 3,
                DeliveryLocation = new Offset(0,1),
                MaterialName = "Information"
            }
        } },
        {"Apple Collector", new BaseBuilding
        {
            Name = "Apple Collector",
            VisualName = "building_Apple Collector",
            occupying = new Offset[]
            {
                new Offset(0,0),
                new Offset(1,0)
            },
            Input = new MaterialInput(),
            Output = new MaterialOutput()
            {
                enabled = true,
                HasToConsume = false,
                DeliverTimer = 3,
                DeliveryLocation = new Offset(0,1),
                MaterialName = "Apple"
            }
        } },
        {"Amazing Product",new BaseBuilding
        {
            Name = "Amazing Product",
            VisualName = "building_Amazing Product",
            occupying = new Offset[]
            {
                new Offset(0,0),
                new Offset(1,0),
                new Offset(1,1),
                new Offset(0,-1),
                new Offset(1,-1),
                new Offset(0,1),
            },
            Input = new MaterialInput(),
            Output = new MaterialOutput()
        }}
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
