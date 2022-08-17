using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class QuestWindow : MonoBehaviour
{
    public QuestController QuestPrefab;

    public List<QuestController> QuestList = new();
    public GameObject ScrollView;

    public void AssignQuest(QuestObject Quest)
    {
        QuestController thisQuest = Instantiate(QuestPrefab, ScrollView.transform);
        QuestList.Add(thisQuest);
        thisQuest.AssignedQuest = Quest;
        thisQuest.GetComponent<TextMeshProUGUI>().text = Quest.Name;
    }

    public void CompleteQuest(QuestObject Quest)
    {
        QuestController thisQuest = QuestList.First(o => o.AssignedQuest == Quest);
        Destroy(thisQuest);
        QuestList.Remove(thisQuest);
    }
}
