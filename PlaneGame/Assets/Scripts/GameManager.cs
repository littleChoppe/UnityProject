using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum GameState
{
    Start,
    Running,
    Pause,
    GameOver,
}
public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    private int score = 0;
    private GameState gameState = GameState.Start;
    private AudioSource bgMusic;
    private Hero hero;
    void Awake()
    {
        Instance = this;
        hero = GameObject.FindGameObjectWithTag("Player").GetComponent<Hero>();
        bgMusic = GetComponent<AudioSource>();
    }

    void Start()
    {
        UIManager.Instance.ShowUI(gameState);
    }

    void Update()
    {
        if (gameState == GameState.Start && Input.GetMouseButtonDown(0))
        {
            gameState = GameState.Running;
            hero.Fire();
            UIManager.Instance.ShowUI(gameState);
            MusicManager.Instance.InitMusic();
            Spawn.Instance.SpawnItem();
        }
    }

    public void AddScore(int score)
    {
        this.score += score;
        UIManager.Instance.UpdateScoreText(this.score);
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
        MusicManager.Instance.StopMusic();
        gameState = GameState.GameOver;
        Spawn.Instance.StopSpawn();
        int highestSocre = PlayerPrefs.GetInt("HighestScore", 0);
        if (this.score > highestSocre)
        {
            highestSocre = this.score;
            PlayerPrefs.SetInt("HighestScore", highestSocre);
        }
        UIManager.Instance.ShowUI(gameState);
        UIManager.Instance.UpdateHighestScoreText(highestSocre);
        UIManager.Instance.UpdateCurrentScoreText(this.score);
        //设置UI
    }
}
