using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    public GameObject wallPrefab; 
    public int wallHeight = 3; 
    public Vector3[] wallPositions; 
    void Start()
    {
        GenerateWalls();
    }

    void GenerateWalls()
    {
        foreach (Vector3 pos in wallPositions)
        {
            for (int y = 0; y < wallHeight; y++)
            {
                Vector3 wallPosition = new Vector3(pos.x, pos.y + y, pos.z);
                Instantiate(wallPrefab, wallPosition, Quaternion.identity, transform);
            }
        }
    }
}
