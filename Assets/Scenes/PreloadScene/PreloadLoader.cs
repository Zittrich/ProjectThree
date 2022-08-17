using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreloadLoader : MonoBehaviour
{
    public static string PreloadScene = "PreloadScene";

    private static PreloadLoader _instance;
    public static PreloadLoader Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        SceneManager.LoadScene(PreloadScene, LoadSceneMode.Additive);
    }
}
