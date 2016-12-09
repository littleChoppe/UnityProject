using UnityEngine;
using System.Collections;

public class UIAttack : MonoBehaviour {

    public static UIAttack Instance;

    private GameObject RedAttackBtn;
    private GameObject NormalAttackBtn;
    private GameObject RangeAttackBtn;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
	void Start () 
    {
        RedAttackBtn = transform.FindChild("RedAttack").gameObject;
        NormalAttackBtn = transform.FindChild("NormalAttack").gameObject;
        RangeAttackBtn = transform.FindChild("RangeAttack").gameObject;
	}

    public void ChangeToOneAttack()
    {
        RedAttackBtn.SetActive(true);
        NormalAttackBtn.SetActive(false);
        RangeAttackBtn.SetActive(false);
    }

    public void ChangeToTwoAttack()
    {
        RedAttackBtn.SetActive(false);
        NormalAttackBtn.SetActive(true);
        RangeAttackBtn.SetActive(true);
    }
}
