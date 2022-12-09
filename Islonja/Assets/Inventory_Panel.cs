using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class Inventory_Panel : MonoBehaviour
{

    [SerializeField] ItemContainer inventory;
    [SerializeField] List<Inventory_Button> buttons;

    private void Start()
    {
        Set_Index();
        Show();

    }

    private void OnEnable()
    {
        Show();
    }
    private void Set_Index()
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            buttons[i].Set_Index(i);
        }
    }

    private void Show()
    {
        for(int i = 0; i < inventory.slots.Count; i++)
        {
            if (inventory.slots[i].item == null)
            {
                buttons[i].Clean(); 
            }
            else
            {
                buttons[i].Set(inventory.slots[i]);
            }
        }
    }
}
