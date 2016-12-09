using UnityEngine;
using System.Collections;

public class ATKAndDemage : MonoBehaviour {

    public int HP = 100;
    public int NormalAttack = 50;
    public float AttackDistance = 1;
    private Animator animator;
    public AudioClip DeathClip; 

    protected void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDemage(int demage)
    {
       
        if (HP > 0)
            HP -= demage;
        if (HP > 0)
        {
            //攻击效果
            if (this.tag == Tags.Monster || this.tag == Tags.Boss)
                animator.SetTrigger("Demage");
        }
        else
        {
            //死亡
            animator.SetTrigger("Death");
            AudioSource.PlayClipAtPoint(DeathClip, transform.position, 1f);
            if (this.tag == Tags.Monster || this.tag == Tags.Boss)
            {
                EnemyManager.Instance.RemoveEnemy(this.gameObject);
                SpawnAward();
                Destroy(this.gameObject, 1);
                this.GetComponent<CharacterController>().enabled = false;
            }
        }
        if (this.tag == Tags.Boss)
            GameObject.Instantiate(Resources.Load("HitBoss"), transform.position + Vector3.up, transform.rotation);
        else if (this.tag == Tags.Monster)
            GameObject.Instantiate(Resources.Load("HitMonster"), transform.position + Vector3.up, transform.rotation);
    }

    void SpawnAward()
    {
        int index = Random.Range(0, 4);
        switch (index)
        {
            case 0:
                GameObject.Instantiate(Resources.Load("AwardDualSword"), transform.position + Vector3.up, Quaternion.identity);
                break;
            case 1:
                GameObject.Instantiate(Resources.Load("AwardGun"), transform.position + Vector3.up, Quaternion.identity);
                break;
            default: break;
        }
    }
}
