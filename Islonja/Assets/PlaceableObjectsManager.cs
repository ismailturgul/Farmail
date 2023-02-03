using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.Progress;

public class PlaceableObjectsManager : MonoBehaviour
{

    [SerializeField] PlaceableObjectContainer placeableObject;
    [SerializeField] Tilemap targetTilemap;

    private void Start()
    {
        GameManager.instance.GetComponent<PlaceableObjectsReferenceManager>().placeableObjectsManager = this;
        VisualizeMap();
    }
    private void OnDestroy()
    {
        for (int i = 0; i < placeableObject.placeableObjects.Count; i++)
        {
            placeableObject.placeableObjects[i].targetObject = null;
        }
    }

    private void VisualizeMap()
    {
        for(int i = 0; i < placeableObject.placeableObjects.Count; i++)
        {
            VisualizeItem(placeableObject.placeableObjects[i]);
        }
    }

    private void VisualizeItem(PlaceableObject placeableObject)
    {
        GameObject go = Instantiate(placeableObject.placeItem.itemPrefab);

        Vector3 position = 
            targetTilemap.CellToWorld(placeableObject.positionOnGrid)
            + targetTilemap.cellSize / 2;

        position -= Vector3.forward * 0.1f;
        go.transform.position = position;

        placeableObject.targetObject = go.transform;
    }

    public void Place(Item item, Vector3Int positionOnGrid)
    {
        PlaceableObject placeableObject = new PlaceableObject(item, positionOnGrid);
        VisualizeItem(placeableObject);
        placeableObject.placeableObjects.Add(placeableObject);
    }
}
