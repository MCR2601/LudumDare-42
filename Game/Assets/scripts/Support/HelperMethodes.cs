using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HelperMethodes {

    public static void Populate<T>(this T[] arr, T value)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = value;
        }
    }
    public static void Populate<T>(this T[,] arr, T value)
    {
        for (int x = 0; x < arr.GetLength(0); x++)
        {
            for (int y = 0; y < arr.GetLength(1); y++)
            {
                arr[x,y] = value;
            }
        }
    }
    public static void Populate(this Tile[,] arr)
    {
        for (int x = 0; x < arr.GetLength(0); x++)
        {
            for (int z = 0; z < arr.GetLength(1); z++)
            {
                arr[x, z] = new Tile(new SimpleCords(x,0,z));
            }
        }
    }
    public static Tile SaveGet(this Tile[,] Map,int x, int z)
    {
        if (x>0 && x < Map.GetLength(0))
        {
            if (z > 0 && z < Map.GetLength(1))
            {
                return Map[x, z];
            }
        }
        return new Tile(new SimpleCords(x, z)) { occupation = TileOccupation.Error};
    }


    public static List<MaterialOffset> RotateBy90Deg(this List<MaterialOffset> set,int turnAmount)
    {
        List<MaterialOffset> newList = new List<MaterialOffset>();

        foreach (var item in set)
        {
            Offset offset = new Offset(item.Offset.x, item.Offset.y);
            for (int i = 0; i < turnAmount; i++)
            {
                // this is some mathematical stuff, very fun but a bit confusing
                offset = new Offset(offset.x - (offset.x - offset.y), offset.y - (offset.x + offset.y));
            }
            newList.Add(new MaterialOffset() { MaterialName = item.MaterialName, Offset = offset});
        }
        return newList;

    }



}
