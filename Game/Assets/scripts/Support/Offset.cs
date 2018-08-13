using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Offset
{
    public int x;
    public int y;

    public Offset(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override string ToString()
    {
        return "{X:" + x + ",Y" + y+ "}";
    }

    public Offset Rotate(int amount)
    {
        Offset offset = new Offset(x, y);

        for (int x = 0; x < amount; x++)
        {
            offset = new Offset(offset.x - (offset.x - offset.y), offset.y - (offset.x + offset.y));
        }
        return  offset;
    }

}
