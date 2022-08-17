using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public void SetVolume(Slider slider )
    {
        AudioListener.volume = slider.value;
    }

    public void ToggleWindow(GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.active);
    }

    public void ToggleFullScreen(Toggle toggle)
    {
        Screen.fullScreen = toggle.isOn;
    }

    public void Leave()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
