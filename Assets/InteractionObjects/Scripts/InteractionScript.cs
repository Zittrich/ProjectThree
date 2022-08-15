using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(OutlineView))]
public class InteractionScript : MonoBehaviour
{
    virtual public void Interact()
    {
        if (GetComponent<TimeConsumer>())
        {
            if(GetComponent<TimeConsumer>().TimeConsumption <= Manager.Use<UIManager>().TimeWindow.Time)
                Manager.Use<UIManager>().TimeWindow.DecreaseTime(GetComponent<TimeConsumer>().TimeConsumption);
            else
            {
                Manager.Use<UIManager>().TimeWindow.DecreaseTime(10000);
                Manager.Use<UIManager>().Mediaplayer.gameObject.SetActive(true);
                Manager.Use<UIManager>().Mediaplayer.Play();
                Invoke("ClosePlayer", (float)Manager.Use<UIManager>().Mediaplayer.length);
            }
        }

    }

    private void ClosePlayer()
    {
        Manager.Use<UIManager>().Mediaplayer.gameObject.SetActive(false);
    }
}
