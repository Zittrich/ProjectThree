using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillScript : MonoBehaviour
{
    public SkillTreeObject AssignedSkill;
    public Image Image;

    private MouseOverDisplay _mouseOverDisplay;
    private void Start()
    {
        Image.sprite = AssignedSkill.Sprite;
        _mouseOverDisplay = Manager.Use<UIManager>().MouseOverDisplay;
    }

    public virtual void SkillUp()
    {
        Debug.Log($"You have Skilled {AssignedSkill.Name}");
    }

    private void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Enter");
        _mouseOverDisplay.gameObject.SetActive(true);
        _mouseOverDisplay.Name.text = AssignedSkill.Name;
    }

    private void OnPointerExit(PointerEventData eventData)
    {
        _mouseOverDisplay.gameObject.SetActive(false);
    }
}
