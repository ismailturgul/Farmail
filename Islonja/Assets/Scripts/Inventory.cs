using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Collectable;

public class Inventory 
{

    public class Slot
    {
        public CollectableType type;
        public int count;
        public int max_Allowed;   

        public Slot()
        {
            type = CollectableType.None;
            count = 0;
            max_Allowed = 0;
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
}
