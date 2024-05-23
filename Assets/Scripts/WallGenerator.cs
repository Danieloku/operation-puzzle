using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    public GameObject wallPrefab; // Prefab de la pared
    public int wallHeight = 2; // Altura de la pared en bloques
    public Transform ground; // Transform del suelo
    public float tileSize = 1.0f; // Tamaño de cada tile

    void Start()
    {
        GenerateWalls();
    }

    void GenerateWalls()
    {
        // Obtener el collider del suelo
        Collider groundCollider = ground.GetComponent<Collider>();

        if (groundCollider == null)
        {
            Debug.LogError("El objeto del suelo no tiene un Collider.");
            return;
        }

        // Obtener los puntos del contorno del suelo
        List<Vector3> contourPoints = GetContourPoints(groundCollider);

        // Generar paredes en los puntos del contorno
        foreach (var point in contourPoints)
        {
            for (int y = 0; y < wallHeight; y++)
            {
                Vector3 wallPosition = new Vector3(point.x, point.y + y * tileSize, point.z);
                Instantiate(wallPrefab, wallPosition, Quaternion.identity, transform);
            }
        }
    }

    List<Vector3> GetContourPoints(Collider collider)
    {
        List<Vector3> points = new List<Vector3>();
        Bounds bounds = collider.bounds;

        // Agregar puntos en los bordes del collider
        points.Add(new Vector3(bounds.min.x, bounds.min.y, bounds.min.z));
        points.Add(new Vector3(bounds.min.x, bounds.min.y, bounds.max.z));
        points.Add(new Vector3(bounds.max.x, bounds.min.y, bounds.min.z));
        points.Add(new Vector3(bounds.max.x, bounds.min.y, bounds.max.z));

        // Agregar puntos adicionales a lo largo del borde si es necesario
        for (float x = bounds.min.x + tileSize; x < bounds.max.x; x += tileSize)
        {
            points.Add(new Vector3(x, bounds.min.y, bounds.min.z));
            points.Add(new Vector3(x, bounds.min.y, bounds.max.z));
        }

        for (float z = bounds.min.z + tileSize; z < bounds.max.z; z += tileSize)
        {
            points.Add(new Vector3(bounds.min.x, bounds.min.y, z));
            points.Add(new Vector3(bounds.max.x, bounds.min.y, z));
        }

        return points;
    }
}
