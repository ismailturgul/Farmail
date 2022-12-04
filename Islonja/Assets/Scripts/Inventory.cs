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
        public Sprite icon;

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

        public void AddItem(Collectable item)
        {
            this.type = item.type;
            this.icon = item.icon;
            count++;
        }

        public void RemoveItem()
        {
            if(count > 0)
            {
                count--;

                // if slot is empty
                if(count == 0)
                {
                    icon = null;
                    type = CollectableType.None;
                }
            }
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

    public void Add(Collectable item)
    {
        foreach(Slot slot in slots)
        {
            if(slot.type == item.type && slot.CanAddItem())
            {
                slot.AddItem(item);
                return;
            }
        }
        foreach(Slot slot in slots)
        {
            if(slot.type == CollectableType.None)
            {
                slot.AddItem(item);
                return;
            }
        }
    }

    public void Remove(int index)
    {
        slots[index].RemoveItem();
    }
}
