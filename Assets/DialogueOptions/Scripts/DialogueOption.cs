using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "dialogue.asset", menuName = "NextGeneration/DialogueOption")]
public class DialogueOption : ScriptableObject
{
    public DialogueOption[] OptionResults =  new DialogueOption[4];
    public string[] OptionNames =  new string[4];
    [Range(-4, 4)] public int[] DialogueFriendshipChange = new int[4];
    public string DialogueText;
    public bool IsEnd;
}
