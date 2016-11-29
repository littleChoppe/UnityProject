using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    public int Attack = 5;
    public float AttackTime = 1;
    private float timer;

    void Start()
    {
        timer = AttackTime;
    }

	void OnTriggerStay(Collider col)
    {
       if (col.tag == Tags.Player)
       {
           timer += Time.deltaTime;
           if (timer >= AttackTime)
               AttackPlayer(col);
       }
    }

    void AttackPlayer(Collider col)
    {
        col.GetComponent<PlayerHealth>().TakeDemage(Attack);
    }
}
