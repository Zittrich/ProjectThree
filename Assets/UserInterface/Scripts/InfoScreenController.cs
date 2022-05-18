using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoScreenController : MonoBehaviour
{
    public Text Name;
    public Text InfoText;
    public Image Portrait;
    public Slider FriendStage;
    public ScrollRect TraitsScreen;
    public TraitScript TraitPrefab;

    private TraitScript _thisTrait;

    public void AddTrait(TraitsObject trait, int position)
    {
        _thisTrait = Instantiate(TraitPrefab, TraitsScreen.content);
        _thisTrait.transform.position -= new Vector3(0, TraitPrefab.GetComponent<RectTransform>().rect.height * 1.3f * position, 0);
        _thisTrait.FillTraitObject(trait);
    }
}
