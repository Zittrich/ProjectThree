using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{
    public int WisdomSkill, SocialSkill;
    public int MaxWisdom = 15, MaxSocial = 15;

    private PlayerSocialDisplay PlayerSocialDisplay;

    private void Start()
    {
        PlayerSocialDisplay = Manager.Use<UIManager>().PlayerSocialDisplay;
    }

    public void IncreaseWisdom(int ammount)
    {
        WisdomSkill += ammount;
        WisdomSkill = Mathf.Clamp(WisdomSkill, 0, MaxWisdom);
        UpdateUI();
    }

    public void IncreaseSocial(int ammount)
    {
        SocialSkill += ammount;
        SocialSkill = Mathf.Clamp(SocialSkill, 0, MaxSocial);
        UpdateUI();
    }

    public void UpdateUI()
    {
        PlayerSocialDisplay.WisdomCounter.text = WisdomSkill.ToString();
        PlayerSocialDisplay.SocialCounter.text = SocialSkill.ToString();
    }
}
