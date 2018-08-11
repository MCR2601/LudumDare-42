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
}
