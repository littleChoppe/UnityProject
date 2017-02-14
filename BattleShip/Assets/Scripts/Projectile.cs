using UnityEngine;
using System.Collections;
using PathologicalGames;

public class Projectile : MonoBehaviour {

    [SerializeField]
    float _speed = 1f;

    [HideInInspector]
    public Unit Target;
    [HideInInspector]
    public Unit Caster;
    [HideInInspector]
    public int Damage;
    [HideInInspector]
    public float AoeRadius;

    void OnSpawned()
    {
        FixedUpdate();
    }
    void FixedUpdate()
    {
        if (Target != null && Caster != null)
        {
            var goal = Target.GetComponentInChildren<Collider>().bounds.center;
            transform.LookAt(goal);
            transform.position = Vector3.MoveTowards(transform.position, goal, _speed);

            if (transform.position == goal)
            {
                if (Target.Hp > 0)
                {
                    Caster.DealDamageAt(Target, Damage);

                    PoolManager.Pools["Projectile"].Despawn(this.transform);
                }
            }
        }
    }
}
