using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityStandardAssets.Characters.ThirdPerson;

public class DialogueController : DialogueOption
{
    public Button[] DialogueButtons = new Button[4];
    public Button QuitButton;
    public Text TextWidget;
    public Text NameWidget;

    private NPCScript _connectedNPC;

    public void StartDialogue(DialogueOption dialogueOption, NPCScript connectedNPC)
    {
        _connectedNPC = connectedNPC;

        DialogueOption thisDialogue = dialogueOption;

        for (int i = 0; i < thisDialogue.OptionResults.Length; i++)
        {
            OptionNames[i] = thisDialogue.OptionNames[i];
            OptionResults[i] = thisDialogue.OptionResults[i];
            DialogueFriendshipChange[i] = thisDialogue.DialogueFriendshipChange[i];
        }

        if (OptionResults.Length == 0)
        {
            QuitButton.gameObject.SetActive(true);
        }

        IsEnd = thisDialogue.IsEnd;
        DialogueText = thisDialogue.DialogueText;

        UpdateInterface();
    }

    public void SelectOption(int dialogueOption)
    {
        DialogueOption thisDialogue = OptionResults[dialogueOption];

        _connectedNPC.ChangeFriendshipLevel(DialogueFriendshipChange[dialogueOption]);
        _connectedNPC.UpdateInfoScreen();

        for (int i = 0; i < thisDialogue.OptionResults.Length; i++)
        {
            OptionNames[i] = thisDialogue.OptionNames[i];
            OptionResults[i] = thisDialogue.OptionResults[i];
            DialogueFriendshipChange[i] = thisDialogue.DialogueFriendshipChange[i];
        }

        if (OptionResults.Length == 0)
        {
            QuitButton.gameObject.SetActive(true);
        }

        IsEnd = thisDialogue.IsEnd;
        DialogueText = thisDialogue.DialogueText;

        UpdateInterface();
    }

    public void SetName(string Name)
    {
        NameWidget.text = Name;
    }

    public void UpdateInterface()
    {

        for (int i = 0; i < OptionResults.Length; i++)
        {
            DialogueButtons[i].GetComponentInChildren<Text>().text = OptionNames[i];

            if (OptionNames[i] == "")
                DialogueButtons[i].gameObject.SetActive(false);
            else
                DialogueButtons[i].gameObject.SetActive(true);
        }

        TextWidget.text = DialogueText;

        if (IsEnd == true)
        {
            QuitButton.gameObject.SetActive(true);
            return;
        }
    }

    public void EndDialogue()
    {
        _connectedNPC.SetIsInDialogue(false);
        QuitButton.gameObject.SetActive(false);
        gameObject.SetActive(false);
        FindObjectOfType<ThirdPersonUserControl>().SetInput(true);
    }
}
