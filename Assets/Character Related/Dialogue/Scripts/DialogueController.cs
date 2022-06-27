using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityStandardAssets.Characters.ThirdPerson;

public class DialogueController : MonoBehaviour
{
    public Button[] DialogueButtons = new Button[4];
    public Button QuitButton;
    public Text TextWidget;
    public Text NameWidget;

    private DialogueOption[] _optionResults = new DialogueOption[4];
    private string[] _optionNames = new string[4];
    [Range(-4, 4)] private int[] _dialogueFriendshipChange = new int[4];
    private string _dialogueText;
    private bool _isEnd;

    private NPCScript _connectedNPC;

    public void StartDialogue(DialogueOption dialogueOption, NPCScript connectedNPC)
    {
        _connectedNPC = connectedNPC;

        DialogueOption thisDialogue = dialogueOption;

        for (int i = 0; i < thisDialogue.OptionResults.Length; i++)
        {
            _optionNames[i] = thisDialogue.OptionNames[i];
            _optionResults[i] = thisDialogue.OptionResults[i];
            _dialogueFriendshipChange[i] = thisDialogue.DialogueFriendshipChange[i];
        }

        if (_optionResults.Length == 0)
        {
            QuitButton.gameObject.SetActive(true);
        }

        _isEnd = thisDialogue.IsEnd;
        _dialogueText = thisDialogue.DialogueText;

        UpdateInterface();
    }

    public void SelectOption(int dialogueOption)
    {
        DialogueOption thisDialogue = _optionResults[dialogueOption];

        _connectedNPC.ChangeFriendshipLevel(_dialogueFriendshipChange[dialogueOption]);
        if(_optionResults[dialogueOption].DialogueTraitUnlock != null)
            _connectedNPC.AddTrait(_optionResults[dialogueOption].DialogueTraitUnlock);
        _connectedNPC.UpdateInfoScreen();

        for (int i = 0; i < thisDialogue.OptionResults.Length; i++)
        {
            _optionNames[i] = thisDialogue.OptionNames[i];
            _optionResults[i] = thisDialogue.OptionResults[i];
            _dialogueFriendshipChange[i] = thisDialogue.DialogueFriendshipChange[i];
        }

        if (_optionResults.Length == 0)
        {
            QuitButton.gameObject.SetActive(true);
        }

        _isEnd = thisDialogue.IsEnd;
        _dialogueText = thisDialogue.DialogueText;

        UpdateInterface();
    }

    public void SetName(string Name)
    {
        NameWidget.text = Name;
    }

    public void UpdateInterface()
    {

        for (int i = 0; i < _optionResults.Length; i++)
        {
            DialogueButtons[i].GetComponentInChildren<Text>().text = _optionNames[i];

            if (_optionNames[i] == "")
                DialogueButtons[i].gameObject.SetActive(false);
            else
                DialogueButtons[i].gameObject.SetActive(true);
        }

        TextWidget.text = _dialogueText;

        if (_isEnd == true)
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
