using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Crops
{

}
public class CropsManager : MonoBehaviour
{

    [SerializeField] TileBase plowed;
    [SerializeField] TileBase seeded;
    [SerializeField] Tilemap targetTilemap;

    Dictionary<Vector2Int, Crops> crops;

    private void Start()
    {
        crops = new Dictionary<Vector2Int, Crops>();
    }

    public bool Check(Vector3Int position)
    {
        bool check = crops.ContainsKey((Vector2Int)position);
        Debug.Log("Tile at position " + position + " is plowed: " + check);
        return check;
    }
    public void Plow(Vector3Int position)
    {
        Debug.Log("Current state of tile before adding: " + crops.ContainsKey((Vector2Int)position));

        if (crops.ContainsKey((Vector2Int)position))
        {
            return;
        }
        Debug.Log("Plowing tile at position: " + position);  // Check the tile plowed or not
        CreatePlowedTile(position);
        Debug.Log("Current state of crops dictionary: " + crops);

    }
    private void CreatePlowedTile(Vector3Int position)
    {
        Crops crop = new Crops();
        crops.Add((Vector2Int)position, crop);

        targetTilemap.SetTile(position, plowed);
    }
    public void Seed(Vector3Int position)
    {
        targetTilemap.SetTile(position, seeded);
    }
}