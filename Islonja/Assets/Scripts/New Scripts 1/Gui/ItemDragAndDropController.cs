using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragAndDropController : MonoBehaviour
{
    public ItemSlot itemSlot;
    [SerializeField] GameObject itemIcon;
    RectTransform iconTransform;
    Image itemIconImage;

    private void Start()
    {
        itemSlot = new ItemSlot();
        iconTransform = itemIcon.GetComponent<RectTransform>();
        itemIconImage = itemIcon.GetComponent<Image>();
    }

    private void Update()
    {
        if(itemIcon.activeInHierarchy)
        {
            iconTransform.position = Input.mousePosition;
            

            if (Input.GetMouseButtonDown(0))
            {
                if(EventSystem.current.IsPointerOverGameObject() == false)
                {
                    Vector3 worldPositon = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    worldPositon.z = 0;
                    ItemSpawnManager.instance.SpawnItem(
                        worldPositon,
                        itemSlot.item,
                        itemSlot.count
                        );

                    itemSlot.Clear();
                    itemIcon.SetActive(false); //to hide the object
                }
            }
        }
    }

    public bool Check(Item item, int count = 1)
    {
        if (itemSlot == null) { return false; }

        if (item.stackable)
        {
            return itemSlot.item == item && itemSlot.count >= count;
        }

        return itemSlot.item == item;
    }

    internal void OnClick(ItemSlot itemSlot)
    {
        if(this.itemSlot.item == null)
        {
            this.itemSlot.Copy(itemSlot);
            itemSlot.Clear();
        }
        else
        {
            Item item = itemSlot.item;
            int count = itemSlot.count;

            itemSlot.Copy(this.itemSlot);
            this.itemSlot.Set(item, count);
        }
        UpdateIcon();
    }

    private void UpdateIcon()
    {
        if(itemSlot.item == null)
        {
            itemIcon.SetActive(false);
        }
        else
        {
            itemIcon.SetActive(true);
            itemIconImage.sprite = itemSlot.item.icon;
        }
    }

    internal void RemoveItem(int count = 1)
    {
        if(itemSlot == null) { return; }

        if(itemSlot.item.stackable)
        {
            itemSlot.count -= count;
            if(itemSlot.count <= 0)
            {
                itemSlot.Clear();
            }
        }
        else
        {
            itemSlot.Clear();
        }
        UpdateIcon();
    }
}
