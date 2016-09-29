using UnityEngine;
using System.Collections;

public enum GameState
{
    Start,
    Playing,
    Over,
}
public class GameManager : MonoBehaviour {

    private static GameManager _instance;
    public int Score = 0;
    public GameState currentGameState = GameState.Start;
    private GameObject bird;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public Transform FinalBg;
	
    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (currentGameState == GameState.Start)
        {
            if (Input.GetMouseButtonDown(0))
            {
                currentGameState = GameState.Playing;
                bird.SendMessage("StartPlay");

            }
        }

        if (currentGameState == GameState.Over)
        {
            GameMenu.Instance.DisplayScore(Score);
        }
	
	}
}
