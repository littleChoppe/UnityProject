using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private int level = 3;
    private MapManager mapManager;
    private static GameManager _instance;
    public static GameManager Instance
    {
        get { return _instance; }
    }
    public int Food = 100;

    void Awake()
    {
        _instance = this;
        mapManager = GetComponent<MapManager>();
        mapManager.InitMap(level);
    }

    public void AddFood(int count)
    {
        Food += count;
    }

    public void ReduceFood(int count)
    {
        Food -= count;
    }
}
