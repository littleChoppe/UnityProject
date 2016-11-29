using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void GameOver(float time)
    {

        Invoke("GameOver", time);
    }
    void GameOver()
    {
        Time.timeScale = 0;
    }
}
