using UnityEngine;
using System.Collections;

public class HeadStatusUI : MonoBehaviour {

    private UILabel name;
    private UILabel hpLabel;
    private UILabel mpLabel;

    private UISlider HPBar;
    private UISlider MPBar;

    private PlayerStatus playerStatus;
	void Start () 
    {
        name = transform.Find("Name").GetComponent<UILabel>();
        HPBar = transform.Find("HP").GetComponent<UISlider>();
        MPBar = transform.Find("MP").GetComponent<UISlider>();

        hpLabel = transform.Find("HP/Thumb/Label").GetComponent<UILabel>();
        mpLabel = transform.Find("MP/Thumb/Label").GetComponent<UILabel>();
        playerStatus = GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<PlayerStatus>();

        UpdateShow();
	}

    public void UpdateShow()
    {
        name.text = "Lv." + playerStatus.Level + " " + playerStatus.Name;
        HPBar.value = playerStatus.CurrentHP;
        MPBar.value = playerStatus.CurrentMP;
        hpLabel.text = playerStatus.CurrentHP + "/" + playerStatus.MaxHP;
        mpLabel.text = playerStatus.CurrentMP + "/" + playerStatus.MaxMP;
    }
}
