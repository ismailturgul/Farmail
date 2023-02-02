using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainerInteractController : MonoBehaviour
{

    ItemContainer targetItemContainer;
    [SerializeField] ItemContainerPanel containerPanel;

    public void Open()
    {
        containerPanel.gameObject.SetActive(true);
    }

    public void Close()
    {
        containerPanel.gameObject.SetActive(false);

    }
}
