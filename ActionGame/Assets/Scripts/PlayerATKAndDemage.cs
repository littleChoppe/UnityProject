using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerATKAndDemage : ATKAndDemage {

    public int AttackB = 80;
    public int AttackRange = 100;
    public int AttackGun = 100;
    public WeaponGun Gun;
    public AudioClip GunClip;
    public AudioClip SwordClip;
    void AttackSingle(int attack)
    {
        GameObject target = null;
        IEnumerator enemyIterator = EnemyManager.Instance.GetEnumerator();
        float minDistance = AttackDistance;

        //找到距离在攻击距离内且距离最小的作为目标
        while(enemyIterator.MoveNext())
        {
            GameObject enemy = (GameObject)enemyIterator.Current;
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                target = enemy;
                minDistance = distance;
            }
        }
        AudioSource.PlayClipAtPoint(SwordClip, transform.position, 1f);
        if (target != null)
        {
            //找到目标后朝向敌人进行伤害
            Vector3 targetPos = target.transform.position;
            targetPos.y = transform.position.y;
            transform.LookAt(targetPos);
            target.GetComponent<ATKAndDemage>().TakeDemage(attack);
        }
    }
    public void AttackADemage()
    {
        AttackSingle(NormalAttack);
    }

    public void AttackBDemage()
    {
        AttackSingle(AttackB);
    }

    public void AttackRangeDemage()
    {
        IEnumerator enemyIterator = EnemyManager.Instance.GetEnumerator();
        List<GameObject> enemyList = new List<GameObject>();
        //找到在攻击范围内进行攻击
        while (enemyIterator.MoveNext())
        {
            GameObject enemy = (GameObject)enemyIterator.Current;
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance <= AttackDistance)
            {
                enemyList.Add(enemy);
            }
        }

        AudioSource.PlayClipAtPoint(SwordClip, transform.position, 1f);
        foreach(GameObject go in enemyList)
            go.GetComponent<ATKAndDemage>().TakeDemage(AttackRange);
    }

    public void AttackGunDemage()
    {
        GameObject target = null;
        IEnumerator enemyIterator = EnemyManager.Instance.GetEnumerator();
        float minDistance = 200;

        //找到距离在攻击距离内且距离最小的作为目标
        while (enemyIterator.MoveNext())
        {
            GameObject enemy = (GameObject)enemyIterator.Current;
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                target = enemy;
                minDistance = distance;
            }
        }

        if (target != null)
        {
            //找到目标后朝向敌人进行伤害
            Vector3 targetPos = target.transform.position;
            targetPos.y = transform.position.y;
            transform.LookAt(targetPos);
        }

        Gun.Attack = AttackGun;
        AudioSource.PlayClipAtPoint(GunClip, transform.position, 1f);
        Gun.Shoot();
    }
}
