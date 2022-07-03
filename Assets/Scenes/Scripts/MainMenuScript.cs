using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void NewGame(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ToggleScreen(GameObject screen)
    {
        screen.SetActive(!screen.active);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
