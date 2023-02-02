using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainerInteractController : MonoBehaviour
{

    ItemContainer targetItemContainer;
    Inventory_Controller inventoryController;
    [SerializeField] ItemContainerPanel containerPanel;
    Transform openedChest;
    [SerializeField] float maxDistance = 0.8f;
    private void Awake()
    {
        inventoryController = GetComponent<Inventory_Controller>();
    }

    private void Update()
    {
        if(openedChest != null)
        {
            float distance = Vector2.Distance(openedChest.position, transform.position);
            if(distance > maxDistance)
            {
                openedChest.GetComponent<Loot_Container_Interact>().Close(GetComponent<Character>());
            }
        }
    }
    public void Open(ItemContainer itemContainer, Transform _openedChest)
    {
        targetItemContainer = itemContainer;
        containerPanel.inventory = targetItemContainer;
        inventoryController.Open();
        containerPanel.gameObject.SetActive(true);
        openedChest = _openedChest;
    }

    public void Close()
    {
        inventoryController.Close();
        containerPanel.gameObject.SetActive(false);
        openedChest = null;
    }
}
