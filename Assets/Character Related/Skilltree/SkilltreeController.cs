using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkilltreeController : UIScript
{
    private GameObject _player;

    private void Start()
    {
        _player = Manager.Use<PlayerManager>().Player;
    }

    public void SkillUp()
    {

    }
}
