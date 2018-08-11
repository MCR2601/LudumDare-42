using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCords {

    public int x;
    public int y;
    public int z;

    public SimpleCords(int x, int z)
    {
        this.x = x;
        this.z = z;
        this.y = 0;
    }

    public SimpleCords(int x, int y, int z)
    {
        this.x = x;
        this.z = z;
        this.y = y;
    }

    public SimpleCords(SimpleCords cords)
    {
        this.x = cords.x;
        this.z = cords.z;
        this.y = cords.y;
    }

    public SimpleCords OffsetBy(Offset offset)
    {
        return new SimpleCords(x + offset.x, z + offset.y);
    }

    public static implicit operator Vector3(SimpleCords simple)
    {
        return new Vector3(simple.x, simple.y, simple.z);
    }

    public static implicit operator SimpleCords(Vector3 vec)
    {
        return new SimpleCords((int)vec.x, (int)vec.y, (int)vec.z);
    }

    public SimpleCords Offset(int x, int y, int z)
    {
        this.x += x;
        this.z += z;
        this.y += y;
        return this;
    }

    public static SimpleCords operator +(SimpleCords a, SimpleCords b)
    {
        return new SimpleCords(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    public static SimpleCords operator -(SimpleCords a, SimpleCords b)
    {
        return new SimpleCords(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    public SimpleCords GetAbove(int height = 1)
    {
        return new SimpleCords(x, y + height, z);
    }
    public SimpleCords GetBelow(int height = 1)
    {
        return new SimpleCords(x, y - height, z);
    }


    public SimpleCords GetInDirection(Direction dir, int distance = 1)
    {
        switch (dir)
        {
            case Direction.North:
                return new SimpleCords(this).Offset(0, 0, distance);
            case Direction.East:
                return new SimpleCords(this).Offset(distance, 0, 0);
            case Direction.South:
                return new SimpleCords(this).Offset(0, 0, -distance);
            case Direction.West:
                return new SimpleCords(this).Offset(-distance, 0, 0);
            default:
                return new SimpleCords(this).Offset(0, 0, 0);
        }
    }

    public override bool Equals(object obj)
    {
        if (!(obj is SimpleCords))
        {
            return false;
        }

        var cords = (SimpleCords)obj;
        return x == cords.x &&
               z == cords.z &&
               y == cords.y;
    }

    public override int GetHashCode()
    {
        var hashCode = 71122146;
        hashCode = hashCode * -1521134295 + x.GetHashCode();
        hashCode = hashCode * -1521134295 + z.GetHashCode();
        hashCode = hashCode * -1521134295 + y.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(SimpleCords a, SimpleCords b)
    {
        if (a.x != b.x)
        {
            return false;
        }
        if (a.z != b.z)
        {
            return false;
        }
        if (a.y != b.y)
        {
            return false;
        }

        return true;
    }
    public static bool operator !=(SimpleCords a, SimpleCords b)
    {
        if (a.x != b.x)
        {
            return true;
        }
        if (a.z != b.z)
        {
            return true;
        }
        if (a.y != b.y)
        {
            return true;
        }

        return false;
    }
    /// <summary>
    /// this methode returns the direction towards a different <see cref="SimpleCords"/>
    /// </summary>
    /// <param name="other">The other cord</param>
    /// <returns>Direction to that other <see cref="SimpleCords"/></returns>
    public Direction GetDirectionTo(SimpleCords other)
    {
        SimpleCords vector = other - this;

        float angle = Mathf.Atan2(vector.x, vector.z);

        if (angle < Mathf.PI / 4 || angle > Mathf.PI / 4 * 7)
        {
            return Direction.East;
        }
        if (angle > Mathf.PI / 4 && angle < Mathf.PI / 4 * 3)
        {
            return Direction.North;
        }
        if (angle > Mathf.PI / 4 * 3 && angle < Mathf.PI / 4 * 5)
        {
            return Direction.West;
        }
        if (angle > Mathf.PI / 4 * 5 && angle < Mathf.PI / 4 * 7)
        {
            return Direction.South;
        }
        return Direction.North;
    }

    public override string ToString()
    {
        return "{" + x + "," + z + "," + y + "}";
    }
}
