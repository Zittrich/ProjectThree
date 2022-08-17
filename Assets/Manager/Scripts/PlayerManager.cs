using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : ManagerModule
{
    public GameObject Player;
    public Camera MainCamera;

    private void Awake()
    {
        MainCamera = FindObjectOfType<FollowCamera>().GetComponent<Camera>();
        Player = FindObjectOfType<QuestController>().gameObject;
        base.Awake();
    }
}
