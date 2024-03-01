using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for hexagon grid properties 
public class Hexagon_Grid : MonoBehaviour
{
    [field:SerializeField] public HexOrientation Orientation { get; private set; }
    [field:SerializeField] public int width {get; private set;}
    [field:SerializeField] public int height {get; private set;}
    [field:SerializeField] public float hexsize {get; private set;}
    [field:SerializeField] public GameObject hex_pre_fab{get; private set;}

    private void OnDrawGizmos()
    {
        for(int z = 0; z < height; z++)
        {
            for(int x = 0; x < width; x++)
            {
                Vector3 centerPosition = HexDimensions.Center(hexsize, x, z, Orientation) + transform.position;
                {
                    for(int i = 0; i < HexDimensions.Corners(hexsize, Orientation).Length; i++)
                    {
                        Gizmos.DrawLine(centerPosition + HexDimensions.Corners(hexsize, Orientation)[i % 6],
                        centerPosition + HexDimensions.Corners(hexsize, Orientation)[(i + 1) % 6]);
                    }
                }
            }
        }
    }
}

public enum HexOrientation
{
    flat_top, pointytop
}