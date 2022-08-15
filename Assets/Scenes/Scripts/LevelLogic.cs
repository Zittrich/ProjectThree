using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class LevelLogic : MonoBehaviour
{
    public LevelStartScreenOption LevelStartUpOption;
    private LevelStartPopUp _levelStartPopUp;

    void Start()
    {
        if (LevelStartUpOption != null)
        {
            _levelStartPopUp = GameObject.FindGameObjectWithTag("LevelStartPopUp").GetComponent<LevelStartPopUp>();
            _levelStartPopUp.SetPopUp(LevelStartUpOption);

            //FindObjectOfType<AgentController>().enabled = false;
        }
        
    }
}
