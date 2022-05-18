using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Trait.asset", menuName = "NextGeneration/NPCTraitObject")]
public class TraitsObject : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Image;
}
