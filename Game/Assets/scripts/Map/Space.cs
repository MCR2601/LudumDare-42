using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for storing all information about the current space/map
/// </summary>
public class Space {

    public Tile[,] Map;

    public List<BaseBuilding> Buildings;

    public List<BaseMaterial> Materials;

    /// <summary>
    /// create a new Space with speciffic size
    /// </summary>
    /// <param name="width">width of the space</param>
    /// <param name="height">width of the space</param>
    public Space(int width, int height)
    {
        Map = new Tile[width, height];
        Map.Populate();
        Buildings = new List<BaseBuilding>();
        Materials = new List<BaseMaterial>();
    }
    /// <summary>
    /// Used to "start/restart" the space
    /// </summary>
    public void Init()
    {
        // spawn a block of dirt?

    }
    
    public Dictionary<string,int> GetAvaiableMaterial()
    {
        Dictionary<string, int> m = new Dictionary<string, int>();
        foreach (var item in Materials)
        {
            if (!m.ContainsKey(item.Name))
            {
                m.Add(item.Name, 1);
            }
            else
            {
                m[item.Name]++;
            }
        }
        return m;
    }

    public bool IsBuildingDelivering()
    {
        foreach (var item in Buildings)
        {
            if (item.Output.ConsumeToGo<=0)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// use this with unplaced Objects
    /// </summary>
    /// <param name="material">the material</param>
    /// <param name="location">position of placement</param>
    public void SpawnMaterial(BaseMaterial material, SimpleCords location)
    {
        Map[location.x, location.z].Material = material;
        Map[location.x, location.z].occupation = TileOccupation.Material;

        material.Place(location);

    }
    /// <summary>
    /// use this with unplaced Objects
    /// </summary>
    /// <param name="building">the building</param>
    /// <param name="location">position of placement</param>
    public void SpawnBuilding(BaseBuilding building, SimpleCords location,int orientation)
    {
        Map[location.x, location.z].Building = building;
        Map[location.x, location.z].occupation = TileOccupation.Building;

        building.PlaceWithOrientation(orientation,location);
    }



}
