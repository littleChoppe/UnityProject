using UnityEngine;
using System.Collections;

public class PlayerAnimationAttack : MonoBehaviour {

    private Animator anim;
    private bool canAttackB = false;
	void Start () 
    {
        anim = GetComponent<Animator>();

        EventDelegate NormalAttackEvent = new EventDelegate(this, "OnNormalBtnClick");
        GameObject.Find("NormalAttack").GetComponent<UIButton>().onClick.Add(NormalAttackEvent);


        EventDelegate RangeAttackEvent = new EventDelegate(this, "OnRangeBtnClick");
        GameObject.Find("RangeAttack").GetComponent<UIButton>().onClick.Add(RangeAttackEvent);

        EventDelegate RedAttackEvent = new EventDelegate(this, "OnRedBtnClick");
        GameObject redButton = GameObject.Find("RedAttack");
        redButton.GetComponent<UIButton>().onClick.Add(RedAttackEvent);
        redButton.SetActive(false);
	}

    public void OnNormalBtnClick()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttackA") && canAttackB)
            anim.SetTrigger("AttackB");
        else
            anim.SetTrigger("AttackA");
    }

    public void OnRangeBtnClick()
    {
        anim.SetTrigger("AttackRange");
    }

    public void OnRedBtnClick()
    {
        anim.SetTrigger("AttackGun");
    }

    public void ToCanAttackB()
    {
        canAttackB = true;
    }

    public void ToCantAttackB()
    {
        canAttackB = false;
    }
}
