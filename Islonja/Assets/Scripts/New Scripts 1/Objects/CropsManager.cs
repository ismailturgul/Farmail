using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class CropsTile
{
    public int growTimer;
    public Crop crop;
}
public class CropsManager : TimeAgent
{

    [SerializeField] TileBase plowed;
    [SerializeField] TileBase seeded;
    [SerializeField] Tilemap targetTilemap;

    Dictionary<Vector2Int, CropsTile> crops;

    private void Start()
    {
        crops = new Dictionary<Vector2Int, CropsTile>();
        onTimeTick += Tick;
        Init();
    }

    public void Tick()
    {
        foreach (CropsTile cropTile in crops.Values)
        {
            if (cropTile.crop == null) { continue; }
            cropTile.growTimer += 1;

            if(cropTile.growTimer >= cropTile.crop.timeToGrow) 
            {
                Debug.Log("iﬂm done growing");
                cropTile.crop = null;
            }
        }
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
    public void Seed(Vector3Int position, Crop toSeed)
    {
        targetTilemap.SetTile(position, seeded);

        crops[(Vector2Int)position].crop = toSeed;
    }
    private void CreatePlowedTile(Vector3Int position)
    {
        CropsTile crop = new CropsTile();
        crops.Add((Vector2Int)position, crop);

        targetTilemap.SetTile(position, plowed);
    }
}