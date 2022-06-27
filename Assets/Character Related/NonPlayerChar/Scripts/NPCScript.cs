using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCScript : MonoBehaviour
{
    public DialogueOption InteractDialogue;
    public string Name;
    public Sprite Portrait;
    public string[] InfoText = new string[5];
    public List<TraitsObject> Traits;

    private int _friendStage;
    private bool _isInDialogue;
    private bool _infoIsOpen;
    int i = 0;

    private DialogueController DialoguePopUp;
    public InfoScreenController InfoScreen { get; private set; }

    private void Start()
    {
        InfoScreen = Manager.Use<UIManager>().InfoScreen;
        DialoguePopUp = Manager.Use<UIManager>().DialogueController;
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

            InfoScreen.FriendStage.value = _friendStage;
            InfoScreen.Name.text = Name;
            InfoScreen.InfoText.text = InfoText[_friendStage];
            InfoScreen.Portrait.sprite = Portrait;
            _infoIsOpen = InfoScreen.gameObject.active;

            if(_infoIsOpen)
            {
                foreach (TraitsObject trait in Traits)
                {
                    InfoScreen.AddTrait(trait, i);
                    i++;
                }
            }

            else
            {
                KillAllChildren(InfoScreen.TraitsScreen.content.gameObject);
                i = 0;
            }
        }
    }

    public void UpdateInfoScreen()
    {
        InfoScreen.FriendStage.value = _friendStage;
        InfoScreen.InfoText.text = InfoText[_friendStage];
        foreach (TraitsObject trait in Traits)
        {
            InfoScreen.AddTrait(trait, i);
        }
    }

    public void ChangeFriendshipLevel(int ammount)
    {
        _friendStage = Mathf.Clamp(_friendStage += ammount, 0, 4);
    }

    public void SetIsInDialogue(bool condition)
    {
        _isInDialogue = condition;
    }

    public void AddTrait(TraitsObject trait)
    {
        Traits.Add(trait);
    }

    private void KillAllChildren(GameObject parent)
    {
        foreach(Transform child in parent.GetComponentInChildren<Transform>())
        {
            Destroy(child.gameObject);
        }
    }
}