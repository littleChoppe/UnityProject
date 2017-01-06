using UnityEngine;
using System.Collections;

public class EquipmentUI : MonoBehaviour {
    public static EquipmentUI Instance;

    public GameObject equipmentItem;
    private bool isShow = false;
    private TweenPosition tween;

    private GameObject Headgear;
    private GameObject Armor;
    private GameObject RightHand;
    private GameObject LeftHand;
    private GameObject Shoe;
    private GameObject Accessory;
    private PlayerStatus playerStatus;
    public int attack = 0;
    public int def = 0;
    public int speed = 0;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        tween = this.GetComponent<TweenPosition>();

        Headgear = transform.Find("Headgear").gameObject;
        Armor = transform.Find("Armor").gameObject;
        RightHand = transform.Find("RightHand").gameObject;
        LeftHand = transform.Find("LeftHand").gameObject;
        Shoe = transform.Find("Shoe").gameObject;
        Accessory = transform.Find("Accessory").gameObject;
        playerStatus = GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<PlayerStatus>();
    }

    void Show()
    {
        isShow = true;
        tween.PlayForward();
    }

    void Hide()
    {
        isShow = false;
        tween.PlayReverse();
    }

    public void SwitchState()
    {
        if (isShow)
            Hide();
        else
            Show();
    }

    public bool GetDressed(ObjectInfor info)
    {
        if (info.ApplyType == ApplicationType.Magician &&
            playerStatus.Type == CharacterType.Swordman)
            return false;

        else if (info.ApplyType == ApplicationType.Swordman &&
            playerStatus.Type == CharacterType.Magician)
            return false;

        GameObject parent = null;
        switch (info.WearType)
        {
            case DressType.Headgear: parent = Headgear; break;
            case DressType.Armor: parent = Armor; break;
            case DressType.RightHand: parent = RightHand; break;
            case DressType.LeftHand: parent = LeftHand; break;
            case DressType.Shoe: parent = Shoe; break;
            case DressType.Accessory: parent = Accessory; break;
        }
        //尝试获取位置上戴的东西，不为空就是有戴
        EquipmentItem item = parent.GetComponentInChildren<EquipmentItem>();
        if (item != null)
        {
            //不能穿戴同样的东西
            if (info.Id == item.GetId())
                return false;
            //把不穿的放回背包
            Inverntory.Instance.PickUpItemById(item.GetId());
            item.SetIcon(info);
        }
        else
        {
            //为空创建一个新的item 挂上去
            GameObject itemGo = NGUITools.AddChild(parent, equipmentItem);
            itemGo.transform.localPosition = Vector3.zero;
            itemGo.GetComponent<EquipmentItem>().SetIcon(info);
        }
        UpdateProperty();
        return true;
    }

    public void TakeOff(EquipmentItem item)
    {
        Inverntory.Instance.PickUpItemById(item.GetId());
        DestroyImmediate(item.gameObject);
        UpdateProperty();
    }

    void UpdateProperty()
    {
        this.attack = 0;
        this.def = 0;
        this.speed = 0;
        EquipmentItem[] equipments = GetComponentsInChildren<EquipmentItem>();
        foreach(EquipmentItem item in equipments)
        {
            this.attack += item.GetInfo().Attack;
            this.def += item.GetInfo().Def;
            this.speed += item.GetInfo().Speed;
        }
    }

   public int GetAttack()
    {
        return this.attack;
    }

    public int GetDef()
   {
       return this.def;
   }

    public int GetSpeed()
    {
        return this.speed;
    }
}
