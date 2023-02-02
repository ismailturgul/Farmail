using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaceableObjectsManager : MonoBehaviour
{

    [SerializeField] PlaceableObjectContainer placeableObject;
    [SerializeField] Tilemap targetTilemap;

    private void Start()
    {
        GameManager.instance.GetComponent<PlaceableObjectsReferenceManager>().placeableObjectsManager = this;
    }

    public void Place(Item item, Vector3Int positionOnGrid)
    {
        GameObject go = Instantiate(item.itemPrefab);
        Vector3 position = targetTilemap.CellToWorld(positionOnGrid);
        position -= Vector3.forward * 0.1f;
        go.transform.position = position;
        placeableObject.placeableObjects.Add(new PlaceableObject(item, go.transform, positionOnGrid));
    }
}
