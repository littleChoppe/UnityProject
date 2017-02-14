using UnityEngine;
using System.Collections;
using PathologicalGames;
public class WarShip : Unit {

    [Header("HP")]
    [SerializeField] int _maxHp = 100;
    public override int MaxHp
    {
        get { return _maxHp; }
    }
    public override int MaxMp
    {
        get { return 0; }
    }

    [Header("Demage")]
    [SerializeField]
    int _demage = 2;
    public override int Attack
    {
        get { return _demage; }
    }

    [Header("Defence")]
    [SerializeField]
    int _defence = 1;
    public override int Defence
    {
        get { return _defence; }
    }

    [Header("Movement")]
    [SerializeField]
    float _followDis = 10.0f;

    [HideInInspector]
    public Transform Goal;  //行走的最终目标

    [Header("Daeth")]
    public GameObject DeathEffect;

    public void OnSpawned()
    {
        Hp = MaxHp;
        Mp = MaxMp;
        State = "IDLE";
    }
    protected override string UpadteState()
    {
        if (State == "IDLE") return UpdateIdle();
        if (State == "MOVING") return UpdateMoving();
        if (State == "CASTING") return UpdateCasting();
        if (State == "DEAD") return UpdateDead();
        return "IDLE";
    }

    string UpdateIdle()
    {
        if (EventDied())
        {
            Debug.Log("死了");
            OnDeath();
            _skillCurrent = -1;
            return "DEAD";
        }
        if (Goal != null)
        {
            Agent.stoppingDistance = 5;
            Agent.destination = Goal.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
            return "MOVING";
        }
        return "IDLE";
    }

    string UpdateMoving()
    {
        if (EventDied())
        {
            OnDeath();
            _skillCurrent = -1;
            return "DEAD";
        }
        return "MOVING";
    }

    string UpdateCasting()
    {
        return "CASTING";
    }

    string UpdateDead()
    {
        return "DEAD";
    }

    bool EventDied()
    {
        return Hp == 0;
    }

    void OnDeath()
    {
        Target = null;
        if (DeathEffect != null)
            PoolManager.Pools["DeathEffect"].Spawn(DeathEffect, transform.position, transform.rotation);
        PoolManager.Pools["WarShips"].Despawn(this.transform);
    }


    public override void OnAggro(Unit obj)
    {
        if (Hp > 0 &&
            obj != null &&
            obj.Hp > 0 &&
            obj.Team != this.Team &&
            CanAttackType(obj.GetType()))
        {
            if (Vector3.Distance(obj.transform.position, transform.position) <
                Vector3.Distance(Target.transform.position, transform.position) * 0.8f)
                Target = obj;
        }
    }

    public override bool CanAttackType(System.Type t)
    {
        return t == typeof(WarShip) || t == typeof(Tower) || t == typeof(Base);
    }
}
