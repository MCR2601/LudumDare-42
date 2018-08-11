using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedBuilding {

    public string BuildingName;
    public SimpleCords Location;
    public int Orientation;

    public DetectedBuilding(string buildingName, SimpleCords location, int orientation)
    {
        BuildingName = buildingName;
        Location = location;
        Orientation = orientation;
    }
}
