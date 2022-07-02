using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class QuestWindow : MonoBehaviour
{
    public QuestController QuestPrefab;

    public List<QuestController> QuestList = new();

    public void AssignQuest(QuestObject Quest)
    {
        QuestController thisQuest = Instantiate(QuestPrefab, transform.position - new Vector3(0, QuestPrefab.GetComponent<RectTransform>().rect.height * QuestList.Count, 0),
            transform.rotation,
            transform);
        QuestList.Add(thisQuest);
        thisQuest.AssignedQuest = Quest;
        thisQuest.GetComponent<TextMeshProUGUI>().text = Quest.name;
    }

    public void CompleteQuest(QuestObject Quest)
    {
        QuestController thisQuest = (QuestController)QuestList.Where(o => o.AssignedQuest == Quest);
        Destroy(thisQuest);
        QuestList.Remove(thisQuest);
    }
}
