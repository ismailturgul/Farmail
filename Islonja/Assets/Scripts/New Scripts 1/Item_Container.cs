using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
    public class ItemSlot
    {
        public Item item;
        public int count;
    }

    [CreateAssetMenu(menuName = "Data/Item Container")]
    
    public class ItemContainer : ScriptableObject
    {
        public List<ItemSlot> slots;
    }
