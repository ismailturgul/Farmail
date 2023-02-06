using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemConverterInteract : Interactable
{

    [SerializeField] Item convertableItem;
    [SerializeField] Item producedItem;

    ItemSlot itemSlot;

    [SerializeField] float timeToProcess = 5f;
    float timer;

    public override void Interact(Character character)
    {
        if(GameManager.instance.dragAndDropController.Check(convertableItem))
        {
            StartItemProcessing();
        }
    }

    private void StartItemProcessing()
    {
        itemSlot.Copy(GameManager.instance.dragAndDropController.itemSlot);
        GameManager.instance.dragAndDropController.RemoveItem();

        timer = 0f;
    }


    private void Update()
    {
        if(itemSlot == null) { return; }
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            if(timer < 0f)
            {
                Debug.Log("Finishing the process");
            }
        }
    }
}
