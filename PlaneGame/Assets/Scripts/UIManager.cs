using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager Instance;
    public Sprite OpenMusicImage;
    public Sprite CloseMusicImage;
    private GameObject startUI;
    private GameObject runningUI;
    private GameObject gameOverUI;

    private Image musicButtonImage;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        musicButtonImage = GameObject.Find("MusicManagerButton").GetComponent<Image>();
        startUI = GameObject.Find("GameStartUI");
        runningUI = GameObject.Find("GameRunningUI");
        gameOverUI = GameObject.Find("GameOver");
    }

    public void SwitchMusicButtonImage()
    {
        if (MusicManager.Instance.IsMute)
            musicButtonImage.sprite = CloseMusicImage;
        else
            musicButtonImage.sprite = OpenMusicImage;

    }

    public void ChangeUI(GameState currentState)
    {
        if (currentState == GameState.GameOver)
        {
            gameOverUI.SetActive(true);
            runningUI.SetActive(false);
            startUI.SetActive(false);
        }
        else if (currentState == GameState.Running)
        {
            gameOverUI.SetActive(false);
            runningUI.SetActive(true);
            startUI.SetActive(false);
        }
        else
        {
            gameOverUI.SetActive(false);
            runningUI.SetActive(false);
            startUI.SetActive(true);
        }
    }
}
