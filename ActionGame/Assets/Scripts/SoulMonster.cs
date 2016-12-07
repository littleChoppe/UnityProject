using UnityEngine;
using System.Collections;

public class SoulMonster : MonoBehaviour {

    public float Speed = 3f;
    public float AttackRange = 1.5f;
    public float AttackTime = 3f;

    private float attackTimer = 0;
    private Transform player;
    private Animator anim;
    private CharacterController cc;
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag(Tags.Player).transform;
        anim = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
        attackTimer = AttackTime;
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 targetPos = player.position;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);
        float distance = Vector3.Distance(targetPos, transform.position);
        if (distance <= AttackRange)    //在攻击范围内
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= AttackTime)  //达到攻击时间
            {
                anim.SetTrigger("Attack");
                //攻击时间间隔
                attackTimer = 0;
            }
            else
            {
                anim.SetBool("Walk", false);
            }
        }
        else  //跟踪目标
        {
            //使Boss 一追上就攻击
            attackTimer = AttackTime;
            anim.SetBool("Walk", true);

            //不设置这个判断的话
            //如果 Boss 在进行攻击时 主角走开，Boss 会在攻击动画下进行移动
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("MonRun"))
            {
                cc.SimpleMove(transform.forward * Speed);
            }
        }
	}
}
