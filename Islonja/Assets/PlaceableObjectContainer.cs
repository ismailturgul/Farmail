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
}

[CreateAssetMenu(menuName ="Data/Placeable Objects Container")]
public class PlaceableObjectContainer : ScriptableObject
{

    public List<PlaceableObject> placeableObjects;

}
