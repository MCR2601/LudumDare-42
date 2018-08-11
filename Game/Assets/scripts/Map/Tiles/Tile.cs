using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a Tile on the ground and can be occupied by a Building or Material
/// </summary>
public class Tile {

    public SimpleCords position;

    /// <summary>
    /// is used to determin what is currently on this tile
    /// </summary>
    public TileOccupation occupation;
    /// <summary>
    /// stores current building if there is one
    /// </summary>
    public BaseBuilding Building;
    /// <summary>
    /// stores current buildung if there is one
    /// </summary>
    public BaseMaterial Material;
    /// <summary>
    /// a tile needs its location for information, it automatically start empty
    /// </summary>
    /// <param name="position">position of the tile</param>
    public Tile(SimpleCords position)
    {
        this.position = position;
        Building = null;
        Material = null;
        occupation = TileOccupation.Empty;
    }

    public bool IsOccupied()
    {
        return occupation > 0 ? true : false;
    }




    //TODO: Add some visual things for this tile (maybe GameObject, texture, etc)


}
