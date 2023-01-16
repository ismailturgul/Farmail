using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedTile : ToolAction
{
    public override bool OnApplyToTileMap(Vector3Int gridposition, TileMapReadController tileMapReadController )
    {
        if( tileMapReadController.cropsManager.Check(gridposition) == false)
        {
            return false;
        }

        tileMapReadController.cropsManager.Seed(gridposition);

        return true;
    }

        
    
}
