using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainerInteractController : MonoBehaviour
{

    ItemContainer targetItemContainer;
    Inventory_Controller inventoryController;
    [SerializeField] ItemContainerPanel containerPanel;

    private void Awake()
    {
        inventoryController = GetComponent<Inventory_Controller>();
    }
    public void Open(ItemContainer itemContainer)
    {
        targetItemContainer = itemContainer;
        containerPanel.inventory = targetItemContainer;
        inventoryController.Open();
        containerPanel.gameObject.SetActive(true);
    }

    public void Close()
    {
        inventoryController.Close();
        containerPanel.gameObject.SetActive(false);

    }
}
