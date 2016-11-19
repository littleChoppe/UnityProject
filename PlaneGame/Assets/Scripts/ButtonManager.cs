using UnityEngine;
using System.Collections;
using System;


public class ButtonManager : MonoBehaviour {

    public static ButtonManager Instance;
    public delegate void BombButtonEvent();
    public event BombButtonEvent BombButtonDown;
    public AudioClip ButtonClip;

    void Awake()
    {
        Instance = this;
    }
    public void OnPauseButtonDown()
    {
        GameManager.Instance.SwitchGameState();
    }

    public void OnBombButtonDown()
    {
        MusicManager.Instance.PlaySound(ButtonClip, this.transform);
        if (BombManager.Instance.ConsumeBomb())
        {
            BombButtonEvent bombButtonDown = BombButtonDown;
            if (bombButtonDown != null)
                bombButtonDown();
        }
    }

    public void OnMusicButtonDown()
    {
        MusicManager.Instance.SwitchMusicState();
        UIManager.Instance.SwitchMusicButtonImage();

    }

    public void OnQuitButtonDown()
    {
        MusicManager.Instance.PlaySound(ButtonClip, this.transform);
        print("click1");
        Application.Quit();
    }

    public  void OnRestartButtonDown()
    {
        MusicManager.Instance.PlaySound(ButtonClip, this.transform);
        print("click2");
        Application.LoadLevel(0);

    }
}
