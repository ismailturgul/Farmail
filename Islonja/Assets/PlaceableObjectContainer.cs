using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlaceableObject
{
    public Item placeItem;
    public Transform targetObject;
    public Vector3Int positionOnGrid;

    public PlaceableObject(Item item, Vector3Int pos)
    {
        placeItem = item; 
        positionOnGrid = pos;
    }
}

[CreateAssetMenu(menuName ="Data/Placeable Objects Container")]
public class PlaceableObjectContainer : ScriptableObject
{

    public List<PlaceableObject> placeableObjects;

}
