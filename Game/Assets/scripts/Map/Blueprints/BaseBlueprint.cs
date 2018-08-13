using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBlueprint  {
    /// <summary>
    /// The name of the Blueprint and at the same time the name of the building
    /// </summary>
    public string Name;
    /// <summary>
    /// materials required from the center, same center as building after build
    /// </summary>
    public List<MaterialOffset> MaterialRequirements;

    private int _posHeight = -1;
    private int _negHeight = 1;
    private int _posWidth = -1;
    private int _negWidth = 1;

    public int PosHeight
    {
        get
        {
            // calculate this value for later use
            if (_posHeight == -1)
            {
                foreach (var item in MaterialRequirements)
                {
                    if (item.Offset.y > _posHeight)
                    {
                        _posHeight = item.Offset.y;
                    }
                }
            }
            return _posHeight;
        }
    }
    public int NegHeight
    {
        get
        {
            // calculate this value for later use
            if (_negHeight == 1)
            {
                foreach (var item in MaterialRequirements)
                {
                    if (item.Offset.y < _negHeight)
                    {
                        _posHeight = item.Offset.y;
                    }
                }
            }
            return _negHeight;
        }
    }
    public int PosWidth
    {
        get
        {
            // calculate this value for later use
            if (_posWidth == -1)
            {
                foreach (var item in MaterialRequirements)
                {
                    if (item.Offset.x > _posWidth)
                    {
                        _posWidth = item.Offset.x;
                    }
                }
            }
            return _posWidth;
        }
    }
    public int NegWidth
    {
        get
        {
            // calculate this value for later use
            if (_negWidth == -1)
            {
                foreach (var item in MaterialRequirements)
                {
                    if (item.Offset.x < _negWidth)
                    {
                        _negWidth = item.Offset.x;
                    }
                }
            }
            return _negWidth;
        }
    }

    public BaseBlueprint()
    {

    }
    /// <summary>
    /// what buildings do you require for this Blueprint?
    /// </summary>
    /// <returns>list of MaterialNames</returns>
    public Dictionary<string,int> GetMaterialRequirements()
    {
        Dictionary<string, int> materials = new Dictionary<string, int>();
        foreach (var item in MaterialRequirements)
        {
            if (!materials.ContainsKey(item.MaterialName))
            {
                materials.Add(item.MaterialName,1);
            }
            else
            {
                materials[item.MaterialName]++;
            }
        }
        return materials;
    }

    public BaseBlueprint GetSaveCopy()
    {
        BaseBlueprint blueprint = new BaseBlueprint();
        blueprint.Name = Name;
        blueprint.MaterialRequirements = new List<MaterialOffset>();
        foreach (var item in MaterialRequirements)
        {
            blueprint.MaterialRequirements.Add(new MaterialOffset() { MaterialName = item.MaterialName, Offset = new Offset(item.Offset.x, item.Offset.y) });
        }
        return blueprint;
    }


}
