using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.Characters.ThirdPerson;

public class LevelStartPopUp : UIScript
{
    public TextMeshProUGUI Infotext;
    public TextMeshProUGUI Headline;


    public void SetPopUp(LevelStartScreenOption levelStartScreenOption)
    {
        Headline.text = levelStartScreenOption.Headline;
        Infotext.text = levelStartScreenOption.InfoText;
    }

    public override void Close()
    {
        FindObjectOfType<ThirdPersonUserControl>().SetInput(true);
        base.Close();
    }
}
