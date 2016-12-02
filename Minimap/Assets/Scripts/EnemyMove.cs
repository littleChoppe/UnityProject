using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

    public float Speed = 5f;
    float timer = 0;
    float changeTime = 4f;
    float h = 0;
    float v = 0;
	void Start () 
    {
        ChanegDir();
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer += Time.deltaTime;
        if (timer >= changeTime)
            ChanegDir();
        Move();
	}

    void ChanegDir()
    {
        timer = 0;
        h = Random.Range(-1f, 1f);
        v = Random.Range(-1f, 1f);
    }
    void Move()
    {
        transform.Translate(new Vector3(h, 0, v) * Speed * Time.deltaTime);
    }
}
