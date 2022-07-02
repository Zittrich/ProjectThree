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
    private QuestObject[] _assignedQuest = new QuestObject[4];
    private string _dialogueText;
    private bool _isEnd;
    private bool _oneTimeUse;
    private DialogueOption _newDialogue;

    private QuestWindow _questWindow;
    private NPCScript _connectedNPC;

    private void Start()
    {
        _questWindow = Manager.Use<UIManager>().QuestWindow;
    }

    public void StartDialogue(DialogueOption dialogueOption, NPCScript connectedNPC)
    {
        _connectedNPC = connectedNPC;

        DialogueOption thisDialogue = dialogueOption;

        for (int i = 0; i < thisDialogue.OptionResults.Length; i++)
        {
            _optionNames[i] = thisDialogue.OptionNames[i];
            _optionResults[i] = thisDialogue.OptionResults[i];
            _dialogueFriendshipChange[i] = thisDialogue.DialogueFriendshipChange[i];
            _assignedQuest[i] = thisDialogue.AssignedQuest[i];
        }

        if (_optionResults.Length == 0)
        {
            QuitButton.gameObject.SetActive(true);
        }

        _isEnd = thisDialogue.IsEnd;
        _oneTimeUse = thisDialogue.OneTimeUse;
        _newDialogue = thisDialogue.NewDialogue;
        _dialogueText = thisDialogue.DialogueText;

        UpdateInterface();
    }

    public void SelectOption(int dialogueOption)
    {
        DialogueOption thisDialogue = _optionResults[dialogueOption];

        _connectedNPC.ChangeFriendshipLevel(_dialogueFriendshipChange[dialogueOption]);
        if(_optionResults[dialogueOption].DialogueTraitUnlock != null)
            _connectedNPC.AddTrait(_optionResults[dialogueOption].DialogueTraitUnlock);
        if (_assignedQuest[dialogueOption] != null)
            _questWindow.AssignQuest(_assignedQuest[dialogueOption]);
        _connectedNPC.UpdateInfoScreen();

        for (int i = 0; i < thisDialogue.OptionResults.Length; i++)
        {
            _optionNames[i] = thisDialogue.OptionNames[i];
            _optionResults[i] = thisDialogue.OptionResults[i];
            _dialogueFriendshipChange[i] = thisDialogue.DialogueFriendshipChange[i];
            _assignedQuest[i] = thisDialogue.AssignedQuest[i];
        }

        if (_optionResults.Length == 0)
        {
            QuitButton.gameObject.SetActive(true);
        }

        _isEnd = thisDialogue.IsEnd;
        _oneTimeUse = thisDialogue.OneTimeUse;
        _newDialogue = thisDialogue.NewDialogue;
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

        if(_oneTimeUse)
        {
            _connectedNPC.InteractDialogue = _newDialogue;
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
