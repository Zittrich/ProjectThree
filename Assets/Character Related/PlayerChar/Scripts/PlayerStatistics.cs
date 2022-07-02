using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{
    private int WisdomSkill, SocialSkill;
    public int MaxWisdom = 15, MaxSocial = 15;

    private int Time;
    public int MaximumTime;

    private PlayerSocialDisplay PlayerSocialDisplay;

    private void Start()
    {
        PlayerSocialDisplay = Manager.Use<UIManager>().PlayerSocialDisplay;
    }

    public void IncreaseTime(int ammount)
    {
        Time += ammount;
        Time = Mathf.Clamp(Time, 0, MaximumTime);
        UpdateUI();
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
        PlayerSocialDisplay.WisdomCounter.text = $"{WisdomSkill}/{MaxWisdom}";
        PlayerSocialDisplay.SocialCounter.text = $"{SocialSkill}/{MaxWisdom}";
    }
}