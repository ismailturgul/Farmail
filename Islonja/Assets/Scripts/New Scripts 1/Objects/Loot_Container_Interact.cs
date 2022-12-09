using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot_Container_Interact : Interactable
{
    [SerializeField] GameObject closed_Chest;
    [SerializeField] GameObject opened_Chest;
    [SerializeField] bool opened = false;

    public override void Interact(Character charachter)
    {
        if (opened == false)
        {
            opened = true;
            closed_Chest.SetActive(false);
            opened_Chest.SetActive(true);
        }
    }
}
