using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill.asset", menuName = "NextGeneration/SkillObject")]
public class SkillTreeObject : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Sprite;
}
