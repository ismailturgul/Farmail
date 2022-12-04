using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{

    public GameObject inventoryPanel;

    public Player player;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        if(!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            Setup();
        }
        else
        {
            inventoryPanel.SetActive(false);
        }
    }
}
