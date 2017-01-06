using UnityEngine;
using System.Collections;
using System.Text;

public class InverntoryDes : MonoBehaviour {

    public static InverntoryDes Instance;

    private UILabel desLabel;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
	void Start () 
    {
        desLabel = GetComponentInChildren<UILabel>();
        desLabel.text = "";
        this.gameObject.SetActive(false);
	}

    public void Show(ObjectInfor info)
    {
        transform.position = UICamera.currentCamera.ScreenToWorldPoint(Input.mousePosition);
        this.gameObject.SetActive(true);
        switch(info.Type)
        {
            case ObjectType.Drug:
                desLabel.text = GetDrugDes(info).ToString();break;
            case ObjectType.Equip:
                desLabel.text = GetEquipDes(info).ToString();break;
            case ObjectType.Mat:
                desLabel.text = GetMatDes(info).ToString();break;
        }

    }

    StringBuilder GetDrugDes(ObjectInfor info)
    {
        StringBuilder des = new StringBuilder();
        des.Append( "名称：" + info.Name + '\n');
        des.Append("+HP：" + info.HP + '\n');
        des.Append("+MP：" + info.MP + '\n');
        des.Append("出售价：" + info.SellPrice + '\n');
        des.Append("购买价：" + info.BuyPrice);
        return des;
    }

    StringBuilder GetEquipDes(ObjectInfor info)
    {
        StringBuilder des = new StringBuilder();
        des.Append("名称：" + info.Name + '\n');
        des.Append("穿戴类型：" + GetDressTypeStr(info.WearType) + '\n');
        des.Append("适用类型：" + GetApplyTypeStr(info.ApplyType) + '\n');
        des.Append("+伤害 " + info.Attack + '\n');
        des.Append("+防御 " + info.Def + '\n');
        des.Append("+速度 " + info.Speed + '\n');
        des.Append("出售价：" + info.SellPrice + '\n');
        des.Append("购买价：" + info.BuyPrice);
        return des;
    }

    string GetDressTypeStr(DressType type)
    {
        switch(type)
        {
            case DressType.Headgear: return "Headgear";
            case DressType.Armor: return "Armor";
            case DressType.LeftHand: return "LeftHand";
            case DressType.RightHand: return "RightHand";
            case DressType.Shoe: return "Shoe";
            case DressType.Accessory: return "Accessory";
            default:    return "Headgear";
        }
    }

    string GetApplyTypeStr(ApplicationType type)
    {
        switch(type)
        {
            case ApplicationType.Swordman: return "Swordman";
            case ApplicationType.Magician: return "Magician";
            case ApplicationType.Common: return "Common";
            default: return "Common";
        }
    }
    StringBuilder GetMatDes(ObjectInfor info)
    {
        StringBuilder des = new StringBuilder();
        des.Append("名称：" + info.Name + '\n');
        des.Append("出售价：" + info.SellPrice + '\n');
        des.Append("购买价：" + info.BuyPrice);
        return des;
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
