using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager Instance;
    public Sprite OpenMusicImage;
    public Sprite CloseMusicImage;
    public GameObject startUI;
    public GameObject runningUI;
    public GameObject gameOverUI;
    private Text scoreText;

    private Text highestScoreText;
    private Text currentScoreTextt;

    private Image musicButtonImage;

    private float timer = 0;
    public Sprite[] StartAnimationSprites;
    public float FrameCountPerSconds = 10;
    private float scondPerFrame;
    public Image StartAnimationImage;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        musicButtonImage = GameObject.Find("MusicManagerButton").GetComponent<Image>();
        scondPerFrame = 1 / FrameCountPerSconds;
    }

    void Update()
    {
        if (GameManager.Instance.GetGameState() == GameState.Start)
        {
            PlayStartAnimation();
        }
        else
        {
            timer = 0;
        }
    }

    void PlayStartAnimation()
    {
        timer += Time.deltaTime;
        int FrameCount = (int)(timer / scondPerFrame);
        int index = FrameCount % StartAnimationSprites.Length;
        StartAnimationImage.rectTransform.sizeDelta = new Vector2(StartAnimationSprites[index].textureRect.width,
            StartAnimationSprites[index].textureRect.height);
        StartAnimationImage.sprite= StartAnimationSprites[index];
    }


    public void SwitchMusicButtonImage()
    {
        if (MusicManager.Instance.IsMute)
            musicButtonImage.sprite = CloseMusicImage;
        else
            musicButtonImage.sprite = OpenMusicImage;

    }

    public void ShowUI(GameState currentState)
    {
        if (currentState == GameState.GameOver)
        {
            gameOverUI.SetActive(true);
            runningUI.SetActive(false);
            startUI.SetActive(false);
            highestScoreText = GameObject.Find("HighestScoreText").GetComponent<Text>();
            currentScoreTextt = GameObject.Find("CurrentScoreText").GetComponent<Text>();
        }
        else if (currentState == GameState.Running)
        {
            gameOverUI.SetActive(false);
            runningUI.SetActive(true);
            startUI.SetActive(false);
            scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
            scoreText.text = "" + 0;
        }
        else if (currentState == GameState.Start)
        {
            gameOverUI.SetActive(false);
            runningUI.SetActive(false);
            startUI.SetActive(true);
        }
    }

    public void UpdateScoreText(int score)
    {

        scoreText.text = "" + score;
    }

    public void UpdateHighestScoreText(int score)
    {
        highestScoreText.text = "" + score;
        print("1");
    }

    public void UpdateCurrentScoreText(int score)
    {
        currentScoreTextt.text = "" + score;
    }
}
