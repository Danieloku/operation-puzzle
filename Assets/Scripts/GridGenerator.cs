using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public int rows = 5; // Número de filas
    public int columns = 5; // Número de columnas
    public float tileSize = 1.0f; // Tamaño de cada tile
    public GameObject tilePrefab; // Prefab del tile

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                // Calcula la posición de cada tile
                Vector3 position = new Vector3(j * tileSize, 0, i * tileSize);
                
                // Instancia el tile en la posición calculada
                Instantiate(tilePrefab, position, Quaternion.identity, transform);
            }
        }
    }
}
