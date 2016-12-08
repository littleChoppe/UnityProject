using UnityEngine;
using System.Collections;

public class MonsterATKAndDemage : ATKAndDemage {

    Transform player;
    PlayerATKAndDemage playerATKAndDemage;
	void Start () 
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag(Tags.Player).transform;
        playerATKAndDemage = player.GetComponent<PlayerATKAndDemage>();
	}

    public void MonAttack()
    {
        if (Vector3.Distance(transform.position, player.position) <= AttackDistance &&
            playerATKAndDemage.HP > 0)
        {
            playerATKAndDemage.TakeDemage(NormalAttack);
        }
    }
}
