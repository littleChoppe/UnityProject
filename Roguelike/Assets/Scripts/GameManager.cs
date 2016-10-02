using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private int level = 3;
    private MapManager mapManager;
    private Text foodText;
    private Text failText;
    private static GameManager _instance;
    private bool sleepStep = true;
    private Image dayImage;
    private Text dayText;
    public static GameManager Instance
    {
        get { return _instance; }
    }
    public int Food = 100;
    public List<Enemy> EnemyList = new List<Enemy>();

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _instance = this;
        InitGame();
    }

    void InitGame()
    {
        mapManager = GetComponent<MapManager>();
        mapManager.InitMap(level);
        EnemyList.Clear();
        foodText = GameObject.Find("FoodText").GetComponent<Text>();
        UpdateFood(0);
        failText = GameObject.Find("FailText").GetComponent<Text>();
        failText.enabled = false;
        dayImage = GameObject.Find("DayImage").GetComponent<Image>();
        dayText = GameObject.Find("DayText").GetComponent<Text>();
        dayText.text = "Day " + level;
        Invoke("HideDayImage", 1);
    }

    void UpdateFood(int foodChange)
    {
        if (foodChange == 0)
        {
            foodText.text = "Food:" + Food;
        }
        else 
        {
            string str = "";
            if (foodChange > 0)
            {
                str = "+";
            }
            foodText.text = str + foodChange + " Food:" + Food;
        }
    }
    public void AddFood(int count)
    {
        Food += count;
        UpdateFood(count);
    }

    public void ReduceFood(int count)
    {
        Food -= count;
        UpdateFood(-count);
        if (Food <= 0)
        {
            failText.enabled = true;
            AudioManager.Instance.PlayerDie();
            AudioManager.Instance.StopBgMusic();
        }
    }

    public void OnPlayerMove()
    {
        if (sleepStep == true)
        {
            sleepStep = false;
        }
        else
        {
            sleepStep = true;
            foreach (var enemy in EnemyList)
            {
                enemy.Move();
            }
        }
    }

    void OnLevelWasLoaded(int sceneLevel) //每次加载场景系统自动调用
    {
        level++;
        InitGame();
    }

    void HideDayImage()
    {
        dayImage.gameObject.SetActive(false);
    }
}
