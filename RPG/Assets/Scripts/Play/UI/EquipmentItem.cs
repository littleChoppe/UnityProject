using UnityEngine;
using System.Collections;

public class EquipmentItem : MonoBehaviour {

    private UISprite sprite;
    private ObjectInfor info;
    private bool isHover = false;
	void Awake () 
    {
        sprite = GetComponent<UISprite>();
	}

    void Update()
    {
        if (isHover)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("脱下");
                EquipmentUI.Instance.TakeOff(this);
            }
        }
    }
    public void SetIcon(ObjectInfor info)
    {
        this.info = info;
        sprite.spriteName = info.IconName;
    }

    void OnHover(bool isHover)
    {
        this.isHover = isHover;
    }

    public int GetId()
    {
        return info.Id;
    }

    public ObjectInfor GetInfo()
    {
        return info;
    }
}
