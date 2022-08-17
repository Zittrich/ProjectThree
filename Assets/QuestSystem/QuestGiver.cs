using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : InteractionScript
{
    public QuestObject AssignedQuestObject;
    public override void Interact()
    {
        Manager.Use<UIManager>().QuestWindow.AssignQuest(AssignedQuestObject);
    }
}
