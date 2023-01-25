using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MarkerManager : MonoBehaviour
{

    [SerializeField] Tilemap targetTilemap;
    [SerializeField] TileBase tile;
    public Vector3Int markedCellPosition;
    Vector3Int oldCellPosition;
    bool show;

    private void Update()
    {
        if(show == false)
        {
            return;
        }
        targetTilemap.SetTile(oldCellPosition, null);  // delete old tile
        targetTilemap.SetTile(markedCellPosition, tile); // add marked tile
        oldCellPosition = markedCellPosition;
    }

    internal void Show(bool selectables)
    {
        show = selectables;
        targetTilemap.gameObject.SetActive(show);
    }
}
