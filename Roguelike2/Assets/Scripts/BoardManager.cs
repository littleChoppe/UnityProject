using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

    [Serializable]
    public class Count
    {
        public int Min;
        public int Max;

        public Count(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }

    public int Columns = 8;
    public int Rows = 8;
    public Count WallCount = new Count(5, 9);
    public Count FoodCount = new Count(1, 5);

    public GameObject Exit;
    public GameObject[] FloorTiles;
    public GameObject[] FoodTiles;
    public GameObject[] WallTiles;
    public GameObject[] EnemyTiles;
    public GameObject[] OuterWallTiles;

    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();

    void InitialiseList()
    {
        gridPositions.Clear();
        for (int x = 1; x < Columns - 1; x++)
        {
            for (int y = 1; y < Rows - 1; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;

        for (int x = -1; x < Columns + 1; x++)
        {
            for (int y = -1; y < Rows + 1; y++)
            {
                GameObject toInstantiate = FloorTiles[Random.Range(0, FloorTiles.Length)];
                if (x == -1 || x == Columns || y == -1 || y == Rows)
                {
                    toInstantiate = OuterWallTiles[Random.Range(0, OuterWallTiles.Length)];
                }
                GameObject instance = GameObject.Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
            }
        }
    }

    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.Remove(randomPosition);
        return randomPosition;
    }

    void LayoutObjectAtRandom(GameObject[] objectArray, int min, int max)
    {
        int objectCount = Random.Range(min, max + 1);
        for (int i = 0; i < objectCount; i++)
        {
            Vector3 position = RandomPosition();
            GameObject titleChoice = objectArray[Random.Range(0, objectArray.Length)];
            Instantiate(titleChoice, position, Quaternion.identity);
        }
    }

    public void SetupScene(int level)
    {
        BoardSetup();
        InitialiseList();
        LayoutObjectAtRandom(FoodTiles, FoodCount.Min, FoodCount.Max);
        LayoutObjectAtRandom(WallTiles, WallCount.Min, WallCount.Max);
        int enemyCount = (int)Mathf.Log(level, 2);
        LayoutObjectAtRandom(EnemyTiles, enemyCount, enemyCount);
        Instantiate(Exit, new Vector3(Columns - 1, Rows - 1, 0f), Quaternion.identity);
    }
}
