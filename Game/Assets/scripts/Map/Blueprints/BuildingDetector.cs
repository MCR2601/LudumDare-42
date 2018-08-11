using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BuildingDetector{
    

    public static List<DetectedBuilding> DetectBuildings(Space space, BlueprintLibrary library)
    {
        List<BaseBlueprint> bPrints = library.GetAllBlueprints();
        bPrints = FindPossibleBlueprints(bPrints, space.getAvaiableMaterial());
        Tile[,] Map = space.Map;

        List<DetectedBuilding> possibleBuildings = new List<DetectedBuilding>();
        for (int x = 0; x < Map.GetLength(0); x++)
        {
            for (int z = 0; z < Map.GetLength(1); z++)
            {
                foreach (var item in bPrints)
                {
                    SimpleCords cord = new SimpleCords(x, z);
                    // rotate 
                    for (int i = 0; i < 4; i++)
                    {                        
                        if (CheckBlueprint(Map, item, cord,i ))
                        {
                            possibleBuildings.Add(new DetectedBuilding(item.Name, cord, i));
                        }
                    }                    
                }
            }
        }
        return possibleBuildings;

    }

    public static bool CheckBlueprint(Tile[,] Map,BaseBlueprint blueprint, SimpleCords location,int rotationToUse = 0)
    {
        int mapWidth = Map.GetLength(0);
        int mapHeight = Map.GetLength(1);

        if (location.x+ blueprint.NegWidth <0)
        {
            return false;
        }
        if (location.y+blueprint.NegHeight<0)
        {
            return false;
        }
        if (location.x + blueprint.PosWidth > mapWidth)
        {
            return false;
        }
        if (location.y + blueprint.PosHeight > mapHeight)
        {
            return false;
        }
        bool exist = true;

        List<MaterialOffset> offsets = blueprint.MaterialRequirements.RotateBy90Deg(rotationToUse);

        foreach (var item in blueprint.MaterialRequirements)
        {
            // skip over logic
            if (!exist)
            {
                continue;
            }
            // do we even have to check if there the materials match?
            if (Map.SaveGet(item.Offset.x + location.x, item.Offset.y + location.z).occupation != TileOccupation.Material)
            {
                exist = false;
            }
            else
            {
                if (Map.SaveGet(item.Offset.x + location.x, item.Offset.y + location.z).Material.Name != item.MaterialName)
                {
                    exist = false;
                }
            }
        }
        return exist;
    }


    private static List<BaseBlueprint> FindPossibleBlueprints(List<BaseBlueprint> bPrints, Dictionary<string, int> dictionary)
    {
        List<BaseBlueprint> newList = new List<BaseBlueprint>();
        foreach (var item in bPrints)
        {
            bool possible = true;
            foreach (var m in item.GetMaterialRequirements())
            {
                if (m.Value > dictionary[m.Key])
                {
                    possible = false;
                }
            }
            if (possible)
            {
                newList.Add(item);
            }
        }
        return newList;
    }
}
