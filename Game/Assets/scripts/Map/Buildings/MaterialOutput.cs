using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// used to define where a building is emitting items, when and what items
/// </summary>
/// <remarks>
/// There are 2 possible times to emit: -some time has passed -resource was delivered
/// </remarks>
public class MaterialOutput{
    /// <summary>
    /// if you want the building to emit material, you have to change this to true
    /// </summary>
    public bool enabled = false;
    /// <summary>
    /// where the Material will be emmited
    /// </summary>
    public Offset DeliveryLocation;
    /// <summary>
    /// Time to deliver after condition was met
    /// </summary>
    public int DeliverTimer;
    /// <summary>
    /// true if deliver should only start after successful consume
    /// </summary>
    public bool HasToConsume;
    /// <summary>
    /// How many should be consumed before starting the timer
    /// </summary>
    public int ConsumeAmount = 1;
    /// <summary>
    /// Name of the material that should be output
    /// </summary>
    public string MaterialName;
    /// <summary>
    /// How long time is remaining until delivery
    /// </summary>
    public int TimeToGo = -1;
    /// <summary>
    /// How many Materials are remaining for consumption
    /// </summary>
    public int ConsumeToGo;

    public MaterialOutput()
    {

    }


    public MaterialOutput GetUsableCopy()
    {
        if (enabled)
        {
            if (HasToConsume)
            {
                return new MaterialOutput()
                {
                    enabled = true,
                    DeliveryLocation = DeliveryLocation,
                    DeliverTimer = this.DeliverTimer,
                    HasToConsume = true,
                    ConsumeAmount = ConsumeAmount,
                    MaterialName = MaterialName,
                    TimeToGo = -1,
                    ConsumeToGo = ConsumeAmount
                };
            }
            else
            {
                return new MaterialOutput()
                {
                    enabled = true,
                    DeliveryLocation = DeliveryLocation,
                    DeliverTimer = DeliverTimer,
                    HasToConsume = false,
                    TimeToGo = DeliverTimer,
                    MaterialName = MaterialName
                };
            }
        }
        else
        {
            return new MaterialOutput();
        }
    }




}
