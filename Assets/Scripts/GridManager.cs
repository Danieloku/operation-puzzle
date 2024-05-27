using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    public Vector2 cellSize = new Vector2(1, 1);
    private Dictionary<Vector2Int, GameObject> grid = new Dictionary<Vector2Int, GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Vector2Int GetGridPosition(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt(worldPosition.x / cellSize.x);
        int y = Mathf.FloorToInt(worldPosition.z / cellSize.y);
        return new Vector2Int(x, y);
    }

    public void AddObjectToGrid(GameObject obj, Vector3 worldPosition)
    {
        Vector2Int gridPos = GetGridPosition(worldPosition);
        grid[gridPos] = obj;
    }

    public void RemoveObjectFromGrid(Vector3 worldPosition)
    {
        Vector2Int gridPos = GetGridPosition(worldPosition);
        if (grid.ContainsKey(gridPos))
        {
            grid.Remove(gridPos);
        }
    }

    public GameObject GetObjectAtGridPosition(Vector2Int gridPos)
    {
        if (grid.ContainsKey(gridPos))
        {
            return grid[gridPos];
        }
        return null;
    }
}
