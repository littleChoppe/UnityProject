using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

	// Use this for initialization
    public Text CurrentScore;
    public Text BestScore;

    private static GameMenu _instance;
    public static GameMenu Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        _instance = this;
        this.gameObject.SetActive(false);
    }

    public void DisplayScore(int currentScore)
    {
        int bestScore = PlayerPrefs.GetInt("score", 0);
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("score", bestScore);
        }

        CurrentScore.text = currentScore.ToString();
        BestScore.text = bestScore.ToString();
        this.gameObject.SetActive(true);
    }

    public void OnClick()
    {
        SceneManager.LoadScene(0);
    }
}
