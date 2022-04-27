using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLogic : MonoBehaviour
{
    public GameObject LevelStartPopUp;

    void Start()
    {
        if (LevelStartPopUp != null)
            LevelStartPopUp.SetActive(true);
    }

    void Update()
    {
        
    }
}
