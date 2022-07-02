using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest.asset", menuName = "NextGeneration/Quest")]
public class QuestObject : ScriptableObject
{
    public string Name;
    public string Description;
    public string Effect;
}
