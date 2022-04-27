using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOption : MonoBehaviour
{
    public DialogueOption[] OptionResults =  new DialogueOption[4];
    public string[] OptionNames =  new string[4];
    [Range(-5, 5)] public int[] DialogueFriendshipChange = new int[4];
    public string DialogueText;
    public bool IsEnd;
}
