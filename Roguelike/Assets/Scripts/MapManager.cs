using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapManager : MonoBehaviour {

    public GameObject[] OutWallArray;
    public GameObject[] FloorArray;
    public GameObject[] WallArray;
    public GameObject[] FoodArray;
    public GameObject[] EnemyArray;
    public GameObject ExitPrefabs;
    public int Rows = 10;
    public int Cols = 10;

    private int minCountWalls = 5;
    private int maxCountWalls = 9;
    private int minFoodCount = 1;
    private int maxFoodCount = 5;
    private const int insideMinIndex = 2;
    private List<Vector2> positionList = new List<Vector2>();
    private Transform map;
	
    public void InitMap(int level)
    {
        map = new GameObject("Map").transform;
        InitBackGround();
        InitList();
        InitItems(WallArray, minCountWalls, maxCountWalls);
        InitItems(FoodArray, minFoodCount, maxFoodCount);
        int enemyCount = (int)Mathf.Log(level, 2.0f);
        InitItems(EnemyArray, enemyCount, enemyCount);

        Vector2 exitPosition = new Vector2(Cols - 2, Rows - 2);
        GameObject exit = GameObject.Instantiate(ExitPrefabs, exitPosition, Quaternion.identity) as GameObject;
        exit.transform.SetParent(map);
    }

    void InitList()
    {
        positionList.Clear();
        for (int x = insideMinIndex; x < Cols - 2; x++)
        {
            for (int y = insideMinIndex; y < Rows - 2; y++)
            {
                positionList.Add(new Vector2(x, y));
            }
        }
    }
    void InitItems(GameObject[] prefabs, int min, int max)
    {
        int count = Random.Range(min, max + 1);
        for (int i = 0; i < count; i++)
        {
            Vector2 pos = RandomPosition();
            GameObject prefab = RandomPrefab(prefabs);
            GameObject go = GameObject.Instantiate(prefab, pos, Quaternion.identity) as GameObject;
            go.transform.SetParent(map);
        }
    }

    Vector2 RandomPosition()
    {
        int positionIndex = Random.Range(0, positionList.Count);
        Vector2 position = positionList[positionIndex];
        positionList.Remove(position);
        return position;
    }

    GameObject RandomPrefab(GameObject[] Prefabs)
    {
        int index = Random.Range(0, Prefabs.Length);
        return Prefabs[index];
    }

    void InitBackGround()
    {
        for (int x = 0; x < Cols; x++)
        {
            for (int y = 0; y < Rows; y++)
            {
                GameObject prefab = RandomPrefab(FloorArray);
                if (x == 0 || y == 0 || x == Cols - 1 || y == Rows - 1)
                {
                    prefab = RandomPrefab(OutWallArray);
                }
                GameObject go = GameObject.Instantiate(prefab,
                       new Vector3(x, y, 0), Quaternion.identity) as GameObject;
                go.transform.SetParent(map);
            }
        }
    }
}
