using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Collectable;

public class ItemManager : MonoBehaviour
{

    public Collectable[] collectableItems;

    private Dictionary<CollectableType, Collectable> collectableitemDict = new Dictionary<CollectableType, Collectable>();

    private void Awake()
    {
        foreach(Collectable item in collectableItems)
        {
            AddItem(item);
        }
    }

    private void AddItem(Collectable item)
    {
        if(!collectableitemDict.ContainsKey(item.type))
        {
            collectableitemDict.Add(item.type, item);
        }
    }

    public Collectable GetItemByType(CollectableType type)
    {
        if(collectableitemDict.ContainsKey(type))
        {
            return collectableitemDict[type];
        }

        return null;
    }
}
