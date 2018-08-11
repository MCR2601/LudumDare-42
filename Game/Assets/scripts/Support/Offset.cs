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

}
