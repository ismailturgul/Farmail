using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class Inventory_Panel : ItemPanel
{
    public override void OnClick(int id)
    {
        GameManager.instance.dragAndDropController.OnClick(inventory.slots[id]);
        Show();
    }
}
