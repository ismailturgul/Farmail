using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Loot_Container_Interact : Interactable
{
    [SerializeField] GameObject closed_Chest;
    [SerializeField] GameObject opened_Chest;
    [SerializeField] bool opened = false;
    [SerializeField] AudioClip onOpenAudio;
    [SerializeField] ItemContainer itemContainer;

    public override void Interact(Character charachter)
    {
        if (opened == false)
        {
            Open(charachter);
                  }
        else
        {
            Close(charachter);
        }
    }

    public void Open(Character charachter)
    {
        opened = true;
        closed_Chest.SetActive(false);
        opened_Chest.SetActive(true);


        AudioManager.instance.Play(onOpenAudio);
        charachter.GetComponent<ItemContainerInteractController>().Open(itemContainer, transform);

    }

    public void Close(Character charachter)
    {
        opened = false;
        closed_Chest.SetActive(true);
        opened_Chest.SetActive(false);


        AudioManager.instance.Play(onOpenAudio);
        charachter.GetComponent<ItemContainerInteractController>().Close();

    }
}
