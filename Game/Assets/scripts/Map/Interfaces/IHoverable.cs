using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// provides Methodes for Objects that can be hovered over
/// </summary>
public interface IHoverable
{
    /// <summary>
    /// Mouse is above the Object for x time
    /// </summary>
    void OnHoverStart();
    /// <summary>
    /// Mouse left the Object after it allready hovered
    /// </summary>
    void OnHoverEnd();

}