using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCompleter : MonoBehaviour
{
    public QuestObject AssignedQuestObject;
    public AudioSource ThisAudioSource;
    private bool _used;

    public void Interact()
    {
        if (!_used)
        {
            _used = true;
            Manager.Use<UIManager>().QuestWindow.CompleteQuest(AssignedQuestObject);
            ThisAudioSource.Play();
        }
    }
}
