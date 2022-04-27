using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCScript : MonoBehaviour
{
    public GameObject InteractionPopUp;

    public void Interact()
    {
        InteractionPopUp.gameObject.SetActive(true);
    }
}
