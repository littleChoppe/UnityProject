using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyManager : MonoBehaviour, IEnumerable {

    public static EnemyManager Instance;

    private Transform player;

    public EnemySpawn[] MonsterSpawnArray;
    public EnemySpawn[] BossSpawnArray;
    public AudioClip VictoryClip;

    private List<GameObject> enemies = new List<GameObject>();

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        player = GameObject.FindGameObjectWithTag(Tags.Player).transform;
    }
	void Start () 
    {
        StartCoroutine(SpawnEnemy());
	}

    IEnumerator SpawnEnemy()
    {
        //第一波生成4个monster,每个生成点生成一个
        SpawnEnemy(MonsterSpawnArray);
        
        //敌人还没死完就等0.2秒
        while (enemies.Count > 0)
            yield return new WaitForSeconds(0.2f);

        //第二波生成 8个monster, 每个生成点生成2个
        SpawnEnemy(MonsterSpawnArray);
        yield return new WaitForSeconds(0.5f);
        SpawnEnemy(MonsterSpawnArray);
        while (enemies.Count > 0)
            yield return new WaitForSeconds(0.2f);

        //第三波生成8 个monster 和 2 个Boss
        SpawnEnemy(MonsterSpawnArray);
        yield return new WaitForSeconds(0.5f);
        SpawnEnemy(MonsterSpawnArray);
        yield return new WaitForSeconds(0.5f);
        SpawnEnemy(BossSpawnArray);
        while (enemies.Count > 0)
            yield return new WaitForSeconds(0.2f);
        AudioSource.PlayClipAtPoint(VictoryClip, transform.position, 1f);

    }

    void SpawnEnemy(EnemySpawn[] enemyArray)
    {
        foreach(EnemySpawn enemy in enemyArray)
            enemies.Add(enemy.SpawnEnemy());
    }
    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }

    public IEnumerator GetEnumerator()
    {
        return enemies.GetEnumerator();
    }
}
