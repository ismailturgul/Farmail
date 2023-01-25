using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Controller : MonoBehaviour
{

    [SerializeField] GameObject panel;
    [SerializeField] GameObject statusPanel;
    [SerializeField] GameObject toolbarPanel;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            panel.SetActive(!panel.activeInHierarchy);
            statusPanel.SetActive(!statusPanel.activeInHierarchy);
            toolbarPanel.SetActive(!toolbarPanel.activeInHierarchy);
        }
    }
}
