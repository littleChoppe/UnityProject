using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour {
    public static Status Instance;

    private TweenPosition tween;
    private bool isShow = false;
    private UIButton[] plusButton;
    private UILabel attackLabel;
    private UILabel defLabel;
    private UILabel speedLabel;
    private UILabel summaryLabel;
    private UILabel remainPoint;

    private PlayerStatus playerStatus;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        tween = GetComponent<TweenPosition>();
        plusButton = GetComponentsInChildren<UIButton>();
        attackLabel = transform.Find("AttackLabel").GetComponent<UILabel>();
        defLabel = transform.Find("DefLabel").GetComponent<UILabel>();
        speedLabel = transform.Find("SpeedLabel").GetComponent<UILabel>();
        summaryLabel = transform.Find("SummaryLabel").GetComponent<UILabel>();
        remainPoint = transform.Find("RemainPoint").GetComponent<UILabel>();
        playerStatus = GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<PlayerStatus>();
    }

    public void SwitchStatus()
    {
        if (isShow)
            Hide();
        else
            Show();
    }

    void Show()
    {
        isShow = true;
        UpdateStatus();
        tween.PlayForward();
    }

    void UpdateStatus()
    {
        attackLabel.text = playerStatus.Attack + " + " + playerStatus.AttackPlus + " + " + EquipmentUI.Instance.GetAttack();
        defLabel.text = playerStatus.Def + " + " + playerStatus.DefPlus + " + " + EquipmentUI.Instance.GetDef();
        speedLabel.text = playerStatus.Speed + " + " + playerStatus.SpeedPlus + " + " + EquipmentUI.Instance.GetSpeed();
        remainPoint.text = playerStatus.RemainPoint.ToString();
        summaryLabel.text = "攻击：" + (playerStatus.Attack + playerStatus.AttackPlus + EquipmentUI.Instance.GetAttack()) + " " +
            "防御：" + (playerStatus.Def + playerStatus.DefPlus + EquipmentUI.Instance.GetDef()) + " " +
            "速度：" + (playerStatus.Speed + playerStatus.SpeedPlus + EquipmentUI.Instance.GetSpeed());

        if (playerStatus.RemainPoint > 0)
        {
            foreach (UIButton btn in plusButton)
                btn.gameObject.SetActive(true);
        }
        else
        {
            foreach (UIButton btn in plusButton)
                btn.gameObject.SetActive(false);
        }
    }
    void Hide()
    {
        isShow = false;
        tween.PlayReverse();
    }

    public void OnAttackPlus()
    {
        if (playerStatus.GetPoint())
        {
            playerStatus.AttackPlus++;
            UpdateStatus();
        }
    }

    public void OnDefPlus()
    {
        if (playerStatus.GetPoint())
        {
            playerStatus.DefPlus++;
            UpdateStatus();
        }
    }

    public void OnSpeedPlus()
    {
        if (playerStatus.GetPoint())
        {
            playerStatus.SpeedPlus++;
            UpdateStatus();
        }
    }

}
