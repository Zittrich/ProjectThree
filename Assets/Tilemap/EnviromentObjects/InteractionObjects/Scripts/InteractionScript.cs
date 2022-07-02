using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionScript : MonoBehaviour
{
    virtual public void Interact()
    {
        if (GetComponent<TimeConsumer>())
        {
            Manager.Use<UIManager>().TimeWindow.DecreaseTime(GetComponent<TimeConsumer>().TimeConsumption);
        }

    }
}
