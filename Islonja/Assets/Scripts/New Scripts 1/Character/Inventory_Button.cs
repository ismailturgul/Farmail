using JetBrains.Annotations;
using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory_Button : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Image highlight;

    int my_Index;

    public void Set_Index(int index)
    { my_Index = index; }

    public void Set(ItemSlot slot)
    {
        icon.gameObject.SetActive(true);
        icon.sprite = slot.item.icon;

        if(slot.item.stackable == true)
        {
            text.gameObject.SetActive(true);
            text.text = slot.count.ToString();
        }
        else
        {
            text.gameObject.SetActive(true);
        }

    }
    public void Clean()
    {
        icon.sprite = null;
        icon.gameObject.SetActive(false);

        text.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ItemPanel itemPanel = transform.parent.GetComponent<ItemPanel>();
        itemPanel.OnClick(my_Index);
    }

    public void Highlight(bool b)
    {
        highlight.gameObject.SetActive(b);
    }
}
