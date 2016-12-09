using UnityEngine;
using System.Collections;

public class PlayerAward : MonoBehaviour {

    public GameObject Gun;
    public GameObject SingleSword;
    public GameObject DualSword;
    public float ExitTime = 10;
    private float timer = 0;

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            SwitchToSingleSword();
        }
    }
    public void GetAward(AwardType awardType)
    {
        if (awardType == AwardType.DualSword)
            SwitchToDualSword();
        else if (awardType == AwardType.Gun)
            SwitchToGun();
    }

    void SwitchToGun()
    {
        timer = ExitTime;
        SingleSword.SetActive(false);
        DualSword.SetActive(false);
        Gun.SetActive(true);
        UIAttack.Instance.ChangeToOneAttack();
    }

    void SwitchToSingleSword()
    {
        timer = 0;
        SingleSword.SetActive(true);
        DualSword.SetActive(false);
        Gun.SetActive(false);
        UIAttack.Instance.ChangeToTwoAttack();
    }

    void SwitchToDualSword()
    {
        timer = ExitTime;
        SingleSword.SetActive(false);
        DualSword.SetActive(true);
        Gun.SetActive(false);
        UIAttack.Instance.ChangeToTwoAttack();
    }
}
