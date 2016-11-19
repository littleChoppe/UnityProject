using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum GameState
{
    Running,
    Pause,
    GameOver,
}
public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    private int score = 0;
    private Text scoreText;
    private GameState gameState = GameState.Running;
    private AudioSource bgMusic;

    void Awake()
    {
        Instance = this;
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        bgMusic = GetComponent<AudioSource>();
    }

    public void AddScore(int score)
    {
        this.score += score;
    }

    void Update()
    {
        scoreText.text = "" + score;
    }

    public GameState GetGameState()
    {
        return gameState;
    }

    public void SwitchGameState()
    {
        if (gameState == GameState.Running)
            SwitchToPause();
        else if (gameState == GameState.Pause)
            SwitchToRunning();
    }

    void SwitchToRunning()
    {
        Time.timeScale = 1;     //这个设置后，以后运行 Time.deltaTime = 0 相当于静止
        gameState = GameState.Running;
        bgMusic.Play();
    }

    void SwitchToPause()
    {
        Time.timeScale = 0;
        gameState = GameState.Pause;
        bgMusic.Pause();
    }

    public void GameOver()
    {
        gameState = GameState.GameOver;
        //设置UI
    }
}
