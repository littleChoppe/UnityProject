using UnityEngine;
using System.Collections;

public class FunctionBar : MonoBehaviour {

	public void OnBagClick()
    {
        Inverntory.Instance.SwitchState();
    }

    public void OnSkillClick()
    {

    }

    public void OnEquipClick()
    {
        EquipmentUI.Instance.SwitchState();
    }

    public void OnStatusClick()
    {
        Status.Instance.SwitchStatus();
    }

    public void OnSettingClick()
    {

    }
}
