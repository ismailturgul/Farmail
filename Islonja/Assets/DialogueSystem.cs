using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI targetText;
    [SerializeField] TextMeshProUGUI nameText;

    DialogueContainer currentDialogue;
    int currentTextLine;
    private void Update()
    {
        if  (Input.GetMouseButtonDown(0))
        {
            PushText();
        }
    }

    private void PushText()
    {
        currentTextLine += 1;
        if(currentTextLine >= currentDialogue.line.Count)
        {
            ConClude();
        }else
        {
            targetText.text = currentDialogue.line[currentTextLine];
        }
    }

    public void Initialize(DialogueContainer dialogueContainer)
    { 
        currentDialogue = dialogueContainer;
        currentTextLine = 0;
        targetText.text = currentDialogue.line[currentTextLine];
    }

    private void ConClude()
    {
        //
    }
}
