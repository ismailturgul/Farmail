using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPanel : MonoBehaviour
{

    public ItemContainer inventory;
    public List<Inventory_Button> buttons;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        Set_Index();
        Show();
    }

    private void OnEnable()
    {
        Show();
    }

    private void LateUpdate()
    {
        if(inventory.isDirty)
        {
            Show();
            inventory.isDirty = false;
        }
    }
    private void Set_Index()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].Set_Index(i);
        }
    }

    public virtual void Show()
    {
        for (int i = 0; i < inventory.slots.Count && i < buttons.Count; i++)
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

    public virtual void OnClick(int id)
    {

    }
}
