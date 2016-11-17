using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;

    public GameObject Award1;
    public GameObject Award2;

    public float RateEnemy1 = 1;
    public float RateEnemy2 = 3;
    public float RateEnemy3 = 10;

    public float RateAward1 = 7;
    public float RateAward2 = 12;
	// Use this for initialization
	void Start () 
    {
        InvokeRepeating("CreateEnemy1", 1, RateEnemy1);
        InvokeRepeating("CreateEnemy2", 3, RateEnemy2);
        InvokeRepeating("CreateEnemy3", 6, RateEnemy3);
        InvokeRepeating("CreateAward1", 10, RateAward1);
        InvokeRepeating("CreateAward2", 10, RateAward2);
	}

    void CreateEnemy1()
    {
        Vector3 position = transform.position;
        position.x = Random.Range(-2.7f, 2.7f);
        GameObject.Instantiate(Enemy1, position, Quaternion.identity);
    }

    void CreateEnemy2()
    {
        Vector3 position = transform.position;
        position.x = Random.Range(-2.6f, 2.6f);
        GameObject.Instantiate(Enemy2, position, Quaternion.identity);
    }

    void CreateEnemy3()
    {
        Vector3 position = transform.position;
        position.x = Random.Range(-2.1f, 2.1f);
        GameObject.Instantiate(Enemy3, position, Quaternion.identity);
    }

    void CreateAward1()
    {
        Vector3 position = transform.position;
        position.x = Random.Range(-2.65f, 2.65f);
        GameObject.Instantiate(Award1, position, Quaternion.identity);
    }

    void CreateAward2()
    {
        Vector3 position = transform.position;
        position.x = Random.Range(-2.65f, 2.65f);
        GameObject.Instantiate(Award2, position, Quaternion.identity);
    }
}
