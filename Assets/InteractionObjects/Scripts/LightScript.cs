using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public bool _enabled { get; private set; }

    private void Start()
    {
        _enabled = gameObject.active;
    }

    public void SwitchActive(bool condition)
    {
        gameObject.SetActive(condition);
        _enabled = condition;
    }
}
