using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveState
{
    /// <summary>
    /// There is currently no Moving going on
    /// </summary>
    Idle,
    /// <summary>
    /// the Material is currently moving up for transport
    /// </summary>
    Raise,
    /// <summary>
    /// the Material is at highest point and can be moved
    /// </summary>
    Move,
    /// <summary>
    /// the Material drops down to the Tile
    /// </summary>
    Lower,
    /// <summary>
    /// the Material returns to its origin
    /// </summary>
    Return
}