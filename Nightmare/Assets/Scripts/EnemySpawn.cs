using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

    public float SpawnTime = 3f;
    public GameObject Enemy;
    public Transform SpawnPoint;
    private float timer = 0;
	void Start () 
    {
        InvokeRepeating("LevelUp", SpawnTime, 60f);
	}

    void LevelUp()
    {
        SpawnTime -= 0.05f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= SpawnTime)
            Spawn();
    }

    void Spawn()
    {
        timer -= SpawnTime;
        Instantiate(Enemy, SpawnPoint.position, SpawnPoint.rotation);
    }
}
