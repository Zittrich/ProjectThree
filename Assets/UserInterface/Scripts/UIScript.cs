using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class UIScript : MonoBehaviour
{
    public virtual void Close()
    {
        gameObject.SetActive(false);
        FindObjectOfType<ThirdPersonUserControl>().SetInput(true);
    }
}
