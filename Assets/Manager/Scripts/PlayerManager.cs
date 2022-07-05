using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : ManagerModule
{
    public GameObject Player;
    public Camera MainCamera;

    private void Awake()
    {
        Player = FindObjectOfType<PlayerInteractionScript>().gameObject;
        MainCamera = FindObjectOfType<FollowCamera>().GetComponent<Camera>();
        base.Awake();
    }
}
