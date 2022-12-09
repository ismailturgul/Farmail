using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Controller : MonoBehaviour
{

    [SerializeField] GameObject panel;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            panel.SetActive(!panel.activeInHierarchy);
        }
    }
}
