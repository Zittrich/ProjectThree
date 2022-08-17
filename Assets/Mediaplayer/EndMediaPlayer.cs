using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EndMediaPlayer : MonoBehaviour
{
    private Mediaplayer _mediaplayer;
    public VideoClip WinClip;
    public VideoClip LoseClip;
    public bool PlayOnStart;

    private float _audio;

    private void Start()
    {
        if (PlayOnStart)
            PlayMedia();
    }

    public void PlayMedia()
    {
        _audio = AudioListener.volume;
        AudioListener.volume = 0;

        Manager.Use<UIManager>().Mediaplayer.gameObject.SetActive(true);
        Manager.Use<UIManager>().Mediaplayer.clip = ThisClip;
        Manager.Use<UIManager>().Mediaplayer.Play();


        Invoke("ClosePlayer", (float)Manager.Use<UIManager>().Mediaplayer.length);
    }

    private void ClosePlayer()
    {
        AudioListener.volume = _audio;
        Manager.Use<UIManager>().Mediaplayer.gameObject.SetActive(false);
    }
}
