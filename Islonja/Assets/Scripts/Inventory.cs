using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Collectable;

[System.Serializable]
public class Inventory 
{
    [System.Serializable]
    public class Slot
    {
        public CollectableType type;
        public int count;
        public int max_Allowed;   

        public Slot()
        {
            type = CollectableType.None;
            count = 0;
            max_Allowed = 99;
        }
        public bool CanAddItem()
        { 
            if(count < max_Allowed)
            {
                return true;
            }
            return false;
        }

        public void AddItem(CollectableType type)
        {
            this.type = type;
            count++;
        }
    }

    public List<Slot> slots = new List<Slot>();

    public Inventory(int numSlots) 
    {
        for(int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    public void Add(CollectableType typeToAdd)
    {
        foreach(Slot slot in slots)
        {
            if(slot.type == typeToAdd && slot.CanAddItem())
            {
                slot.AddItem(typeToAdd);
                return;
            }
        }
        foreach(Slot slot in slots)
        {
            if(slot.type == CollectableType.None)
            {
                slot.AddItem(typeToAdd);
                return;
            }
        }
    }
}
