using UnityEngine;
using System.Collections;

public class BarNPC : NPC {

    public TweenPosition Quest;
    public UILabel Des;
    public GameObject OK;
    public GameObject Accept;
    public GameObject Cancel;
    public int killedCount = 0;

    private bool isInTask = false;

	void Start () 
    {
        Quest.gameObject.SetActive(false);
	}

    void OnMouseDown()
    {
        if (!isInTask)
            ShowTask();
        else
            ShowProcess();

        ShowQuest();
    }

    void ShowQuest()
    {
        Quest.gameObject.SetActive(true);
        Quest.PlayForward();
    }

    void HideQuest()
    {
        Quest.PlayReverse();
        Quest.gameObject.SetActive(false);
    }
	
    void ShowTask()
    {
        Des.text = "任务：\n杀死10只小野狼\n\n\n奖励：\n1000金币";
        Accept.SetActive(true);
        Cancel.SetActive(true);
        OK.SetActive(false);
    }

    void ShowProcess()
    {
        Des.text = "你已经杀死了" + killedCount + "/10只小野狼\n\n\n奖励：\n1000金币";
        Accept.SetActive(false);
        Cancel.SetActive(false);
        OK.SetActive(true);
    }

    public void OnCancelButtonClick()
    {
        HideQuest();
    }

    public void OnCloseButtonClick()
    {
        HideQuest();
    }

    public void OnAcceptButtonClick()
    {
        isInTask = true;
        ShowProcess();
    }

    public void OnOkButtonClick()
    {
        if (killedCount < 10)
        {
            HideQuest();
        }
        else
        {
            isInTask = false;
            Inverntory.Instance.AddCoin(1000);
            killedCount = 0;
            ShowTask();
        }
    }
}
