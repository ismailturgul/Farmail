using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json.Bson;

public class Slot_UI : MonoBehaviour
{
    public Image itemIcon;
    public TextMeshPro quantityText;


    public void SetItem(Inventory.Slot slot)
    {
        if(slot != null)
        {
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1,1,1);
            quantityText.text = slot.count.ToString();
        }
    }

    public void SetEmpty()
    {
        itemIcon.sprite = null;
        itemIcon.color = new Color(1, 1, 1, 0);
        quantityText.text = "";  // display text if theres nothing inside the slot 
    }

}
