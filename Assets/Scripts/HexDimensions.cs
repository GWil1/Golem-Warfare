using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Algorithm used to generate gexagon grid pattern. Mathmatical formulas used from https://www.redblobgames.com/grids/hexagons/

public static class HexDimensions
{
    public static float OuterRadius(float HexSize)
    {
        return HexSize;
    }

    public static float InnerRadius(float HexSize)
    {
        return HexSize * 0.866025404f;
    }

    public static Vector3[] Corners(float HexSize, HexOrientation orientation)
    {
        Vector3[] corners = new Vector3[6];

        for(int i = 0; i < 6; i++)
        {
            corners[i] = Corners(HexSize, orientation, i);
        }
        return corners;
    }

    public static Vector3 Corners(float HexSize, HexOrientation orientation, int index)
    {
        float angle = 60f * index;
        if(orientation == HexOrientation.pointytop)
        {
            angle += 30f;
        }

        Vector3 corners = new Vector3(HexSize * Mathf.Cos(angle * Mathf.Deg2Rad), 0f,
            HexSize * Mathf.Sin(angle * Mathf.Deg2Rad));
            {
                return corners; 
            }
    }

    public static Vector3 Center(float HexSize, int x, int z, HexOrientation orientation)
    {
        Vector3 centerPosition;
        {
            if(orientation == HexOrientation.pointytop)
            {
                centerPosition.x = (x + z * 0.5f - z / 2) * (InnerRadius(HexSize) * 2f);
                centerPosition.y = 0f;
                centerPosition.z = z * (OuterRadius(HexSize) * 1.5f);
            }

            else
            {
                centerPosition.x = (x) * (OuterRadius(HexSize) * 1.5f);
                centerPosition.y = 0f;
                centerPosition.z = (z + x * 0.5f - x / 2) * (InnerRadius(HexSize) * 2f);
            }
        }
        return centerPosition;
    }
}