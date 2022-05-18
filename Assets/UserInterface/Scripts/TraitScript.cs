using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TraitScript : MonoBehaviour
{
    public Image Sprite;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Description;

    public void FillTraitObject(TraitsObject trait)
    {
        Sprite.sprite = trait.Image;
        Name.text = trait.name;
        Description.text = trait.Description;
    }
}
