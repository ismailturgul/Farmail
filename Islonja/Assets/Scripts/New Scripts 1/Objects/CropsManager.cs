using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

[Serializable]
public class CropsTile
{
    public int growTimer;
    public int growStage;
    public Crop crop;
    public SpriteRenderer renderer;
    public float damage;
    public Vector3Int position;

    public bool Complete
    {
        get {
            if(crop == null) {return false; } 
            return growTimer >= crop.timeToGrow;
        }
    }
    internal void Harvested()
    {
        growTimer = 0;
        growStage = 0;
        crop = null;
        renderer.gameObject.SetActive(false);
        damage = 0;
    }
}
public class CropsManager : MonoBehaviour
{
    public TilemapCropsManager cropsManager;
    public void PickUp(Vector3Int position)
    {
        if (cropsManager == null)
        {
            Debug.LogWarning("No Tilemap cropsmanager are referenced in the cropsmanager");
            return;
        }
        cropsManager.PickUp(position);
    }
    public bool Check(Vector3Int position)
    {
        if (cropsManager == null)
        {
            Debug.LogWarning("No Tilemap cropsmanager are referenced in the cropsmanager");
            return false;
        }
        return cropsManager.Check(position);
    }

    public void Seed(Vector3Int position,Crop toSeed)
    {
        if (cropsManager == null)
        {
            Debug.LogWarning("No Tilemap cropsmanager are referenced in the cropsmanager");
            return;
        }
        cropsManager.Seed(position, toSeed);
    }

    public void Plow(Vector3Int position)
    {
            if (cropsManager == null) 
            {
                Debug.LogWarning("no tilemap...");
                return;
            } 

            cropsManager.Plow(position);
    }
}
