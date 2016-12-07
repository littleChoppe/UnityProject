using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

    public GameObject EnemyPrefab;

    public GameObject SpawnEnemy()
    {
        return Instantiate(EnemyPrefab, transform.position, transform.rotation) as GameObject;
    }
}
