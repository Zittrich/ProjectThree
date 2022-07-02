using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeWindow : MonoBehaviour
{
    public TextMeshProUGUI RemainingTime;
    public int Time;

    private void Start()
    {
        UpdateUI();
    }

    public void DecreaseTime(int ammount)
    {
        Time -= ammount;
        UpdateUI();

        Time = Mathf.Clamp(Time, 0, int.MaxValue);
    }

    private void UpdateUI()
    {
        RemainingTime.text = Time.ToString();
    }
}
