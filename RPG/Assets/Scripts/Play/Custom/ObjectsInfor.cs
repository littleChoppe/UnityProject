using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ObjectType
{
    Drug,
    Equip,
    Mat,
}

public enum DressType
{
    Headgear,
    Armor,
    RightHand,
    LeftHand,
    Shoe,
    Accessory,
}

public enum ApplicationType
{
    Swordman,
    Magician,
    Common,
}
public class ObjectsInfor : MonoBehaviour {

    public static ObjectsInfor Instance;
    public TextAsset ObjectInfoListText;

    private Dictionary<int, ObjectInfor> objectInforDic = new Dictionary<int, ObjectInfor>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        ReadInfor();
        Debug.Log(objectInforDic.Keys.Count);
        foreach(KeyValuePair<int, ObjectInfor> item in objectInforDic)
        {
            Debug.Log(item.Value.Id + " " + item.Value.Name + " " + item.Value.IconName +
                " " + item.Value.Type + " " + item.Value.HP + " " + item.Value.MP + " " +
                item.Value.SellPrice + " " + item.Value.BuyPrice + "\n");
        }
    }

    public ObjectInfor GetObjectInfoById(int id)
    {
        ObjectInfor info = null;
        objectInforDic.TryGetValue(id, out info);
        return info;
    }
    void ReadInfor()
    {
        string inforText = ObjectInfoListText.text;
        string[] ObjectsList = inforText.Split('\n');
        foreach(string str in ObjectsList)
        {
            string[] item = str.Split(',');
            ObjectInfor itemInfo = new ObjectInfor();
            itemInfo.Id = int.Parse(item[0]);
            itemInfo.Name = item[1];
            itemInfo.IconName = item[2];
            itemInfo.Type = ObjectType.Drug;
            switch(item[3])
            {
                case "Drug": 
                    itemInfo.Type = ObjectType.Drug;break;
                case "Equip":
                     itemInfo.Type = ObjectType.Equip;break;
                case "Mat":
                    itemInfo.Type = ObjectType.Mat; break;
            }

            switch(itemInfo.Type)
            {
                case ObjectType.Drug:
                    ReadDrugInfo(item, itemInfo);break;
                case ObjectType.Equip:
                    ReadEquipInfo(item, itemInfo); break;
                case ObjectType.Mat:
                    ReadMatgInfo(item, itemInfo);break;
            }

            if (itemInfo.Type == ObjectType.Drug)
            {
                ReadDrugInfo(item, itemInfo);
            }
            objectInforDic.Add(itemInfo.Id, itemInfo);
        }
    }

    void ReadDrugInfo(string[] item, ObjectInfor itemInfo)
    {
        itemInfo.HP = int.Parse(item[4]);
        itemInfo.MP = int.Parse(item[5]);
        itemInfo.SellPrice = int.Parse(item[6]);
        itemInfo.BuyPrice = int.Parse(item[7]);
    }

    void ReadEquipInfo(string[] item, ObjectInfor itemInfo)
    {
        itemInfo.Attack = int.Parse(item[4]);
        itemInfo.Def = int.Parse(item[5]);
        itemInfo.Speed = int.Parse(item[6]);
        itemInfo.SellPrice = int.Parse(item[9]);
        itemInfo.BuyPrice = int.Parse(item[10]);
        itemInfo.WearType = SwithStringDressToType(item[7]);
        itemInfo.ApplyType = SwitchApplyStrToType(item[8]);
    }

    DressType SwithStringDressToType(string dressStr)
    {
        switch(dressStr)
        {
            case "Headgear":
                return DressType.Headgear;
            case "Armor":
                return DressType.Armor;
            case "RightHand":
                return DressType.RightHand;
            case "LeftHand":
                return DressType.LeftHand;
            case "Shoe":
                return DressType.Shoe; 
            case "Accessory":
                return DressType.Accessory;
            default:
                return DressType.Headgear;
        }
    }

    ApplicationType SwitchApplyStrToType(string appStr)
    {
        switch(appStr)
        {
            case "Swordman":
                return ApplicationType.Swordman;
            case "Magician":
                return ApplicationType.Magician;
            case "Common":
                return ApplicationType.Common;
            default:
                return ApplicationType.Common;
        }
    }

    void ReadMatgInfo(string[] item, ObjectInfor itemInfo)
    {

    }
}

public class ObjectInfor
{
    public int Id;
    public string Name;
    public string IconName;
    public ObjectType Type;
    public int HP;
    public int MP;
    public int SellPrice;
    public int BuyPrice;
    public int Attack;
    public int Def;
    public int Speed;
    public DressType WearType;
    public ApplicationType ApplyType;
}
