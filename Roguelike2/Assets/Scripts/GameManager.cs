using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private BoardManager boardScript;
    public static GameManager Instance = null;

    public int level = 3;
	void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(this);

        boardScript = GetComponent<BoardManager>();
        InitGame();
    }

    void InitGame()
    {
        boardScript.SetupScene(level);
    }
}
