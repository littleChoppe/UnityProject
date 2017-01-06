using UnityEngine;
using System.Collections;

public class InverntoryItem : UIDragDropItem{
    private int id;
    private UISprite sprite;
    private ObjectInfor info;
    private bool isHover = false;
    private InverntoryItemGrid parent;
    void Awake()
    {
        base.Awake();
        sprite = GetComponent<UISprite>();
    }

    public void SetParent(InverntoryItemGrid parent)
    {
        this.parent = parent;
    }

    void Update()
    {
        if (isHover && Input.GetMouseButtonDown(1))
        {
            if (info.Type == ObjectType.Equip)
            {
                bool success = EquipmentUI.Instance.GetDressed(info);
                if (success)
                    ConsumeItem();
            }
        }

    }

    protected override void OnDragDropStart()
    {
        base.OnDragDropStart();
        parent.HideCountLabel();
        sprite.alpha = 0.7f;
    }

    //拖拽结束后调用
    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);
        //拖到背包UI外面当丢弃物品
        if ((surface == null) ||
            (surface.tag != Tags.InverntoryItem &&
               surface.tag != Tags.InverntoryItemGrid &&
               surface.tag != Tags.Inverntory))
        {
            parent.Clear();
            Destroy(gameObject);
            return;
        }
        //拖拽有三种情况
        //拖到空格处
        //拖到自己身上
        //拖到有物品的地方
        if (surface != null)
        {
            //Debug.Log(surface.tag);
            //拖到空格处
            if (surface.tag == Tags.InverntoryItemGrid && 
                surface != parent.gameObject)
            {
                //把物体放到新空格下，重新设置信息
                int id = parent.GetId();
                int count = parent.GetCount();
                parent.Clear();
                parent = surface.GetComponent<InverntoryItemGrid>();
                this.transform.parent = surface.transform;
                parent.SetItemById(id, count);
            }
            //拖到有物品的地方
            else if (surface.tag == Tags.InverntoryItem)
            {
                //交换信息
                InverntoryItemGrid surfaceGrid = surface.transform.parent.GetComponent<InverntoryItemGrid>();
                int id = parent.GetId();
                int count = parent.GetCount();
                parent.SetItemById(surfaceGrid.GetId(), surfaceGrid.GetCount());
                surfaceGrid.SetItemById(id, count);
            }

        }
        transform.localPosition = Vector3.zero;
        parent.ShowCountLabel();
        sprite.alpha = 1;
    }

    public void SetIconById(int id)
    {
        this.id = id;
        info = ObjectsInfor.Instance.GetObjectInfoById(id);
        sprite.spriteName = info.IconName;
        sprite.depth = 7;
    }

    public int GetId()
    {
        return id;
    }

    void OnHover(bool isOver)
    {
        isHover = isOver;
        if (isOver)
        {
            InverntoryDes.Instance.Show(info);
        }
        else
            InverntoryDes.Instance.Hide();
    }
     void ConsumeItem()
    {
        if (parent.GetCount() > 1)
            parent.ReduceCount();
        else
        {
            parent.Clear();
            Destroy(this.gameObject);
        }
    }

}
