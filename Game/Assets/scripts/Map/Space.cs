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
    





}
