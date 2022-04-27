using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCScript : MonoBehaviour
{
    public DialogueOption InteractDialogue;
    public string Name;
    public string[] InfoText = new string[5];
    public Sprite Portrait;
    private int FriendStage;

    private bool _isInDialogue;
    private bool _infoIsOpen;

    private DialogueController DialoguePopUp;
    public InfoScreenController InfoScreen { get; private set; }

    private void Start()
    {
        InfoScreen = GameObject.FindGameObjectWithTag("NPCInfoScreen").GetComponent<InfoScreenController>();
        DialoguePopUp = GameObject.FindGameObjectWithTag("DialogueController").GetComponent<DialogueController>();
        InfoScreen.gameObject.SetActive(false);
        DialoguePopUp.gameObject.SetActive(false);
    }

    public void Interact()
    {
        if (!_isInDialogue)
        {
            if (_infoIsOpen)
                ToggleInfoScreen();

            DialoguePopUp.gameObject.SetActive(true);
            DialoguePopUp.StartDialogue(InteractDialogue, this);
            DialoguePopUp.SetName(Name);
            SetIsInDialogue(true);
        }
    }

    public void ToggleInfoScreen()
    {
        if (!_isInDialogue)
        {
            InfoScreen.gameObject.SetActive(!InfoScreen.gameObject.active);

            InfoScreen.FriendStage.value = FriendStage;
            InfoScreen.Name.text = Name;
            InfoScreen.InfoText.text = InfoText[FriendStage];
            InfoScreen.Portrait.sprite = Portrait;
            _infoIsOpen = InfoScreen.gameObject.active;
        }
    }

    public void UpdateInfoScreen()
    {
        InfoScreen.FriendStage.value = FriendStage;
        InfoScreen.InfoText.text = InfoText[FriendStage];
    }

    public void ChangeFriendshipLevel(int ammount)
    {
        FriendStage = Mathf.Clamp(FriendStage += ammount, 0, 4);
    }

    public void SetIsInDialogue(bool condition)
    {
        _isInDialogue = condition;
    }
}
