using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : InteractionScript
{
    public QuestObject AssignedQuestObject;
    public AudioSource ThisAudioSource;
    private bool _used;

    public override void Interact()
    {
        if (!_used)
        {
            _used = true;
            Manager.Use<UIManager>().QuestWindow.AssignQuest(AssignedQuestObject);
            ThisAudioSource.Play();
        }
    }
}
