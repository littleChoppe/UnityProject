using UnityEngine;
using System.Collections;

public class BossATKAndDemage : ATKAndDemage {

    Transform player;
    PlayerATKAndDemage playerATKAndDemage;
    public AudioClip AttackClip;
    void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag(Tags.Player).transform;
        playerATKAndDemage = player.GetComponent<PlayerATKAndDemage>();
    }

    void AttackPlayer()
    {
        AudioSource.PlayClipAtPoint(AttackClip, transform.position, 1f);
        if (Vector3.Distance(transform.position, player.position) <= AttackDistance &&
           playerATKAndDemage.HP > 0)
        {
            playerATKAndDemage.TakeDemage(NormalAttack);
        }
    }

    public void Attack1()
    {
        AttackPlayer();
    }

    public void Attack2()
    {
        AttackPlayer();
    }
}
