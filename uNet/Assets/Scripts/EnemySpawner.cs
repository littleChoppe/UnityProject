using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour {

    public GameObject EnemyPrefab;
    public int Count;

    public override void OnStartServer()
    {
        for (int i = 0; i < Count; i++)
        {
            Vector3 position = new Vector3(Random.Range(-6f, 6f), 0, Random.Range(-6f, 6f));
            Quaternion rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            GameObject enemy = Instantiate(EnemyPrefab, position, rotation) as GameObject;
            NetworkServer.Spawn(enemy);
        }
    }
}
