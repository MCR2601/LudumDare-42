using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to define where a building is sucking up items as well as when and what items
/// </summary>
public class MaterialInput{

    /// <summary>
    /// if you want the building to emit material, you have to change this to true
    /// </summary>
    public bool enabled = false;
    /// <summary>
    /// where the Material will be retrieved
    /// </summary>
    public Offset InputLocation;
    /// <summary>
    /// The amount of material after which input stops and waits for the output to call back, if set to 0 there will be no locking
    /// </summary>
    public int ConsumeAmount = 1;
    /// <summary>
    /// Name of the material that should be sucked in
    /// </summary>
    public string MaterialName;
    /// <summary>
    /// How many Materials are remaining for consumption
    /// </summary>
    public int ConsumeToGo;

    public MaterialInput()
    {

    }
    public MaterialInput GetUsableCopy()
    {
        if (enabled)
        {
            return new MaterialInput()
            {
                enabled = true,
                InputLocation = InputLocation,
                ConsumeAmount = ConsumeAmount,
                MaterialName = MaterialName,
                ConsumeToGo = ConsumeAmount
            };

        }
        else
        {
            return new MaterialInput();
        }
    }






}
