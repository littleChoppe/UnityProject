using UnityEngine;
using System.Collections;

public class InverntoryItemGrid : MonoBehaviour {

    private int id = 0;
    private int itemCount = 0;
    private UILabel countLabel;
	void Start () 
    {
        countLabel = GetComponentInChildren<UILabel>();
        countLabel.gameObject.SetActive(false);
	}


    /// <summary>
    /// 当把物体放到一个空格子后根据物体的ID显示物体的样子
    /// </summary>
    /// <param name="id"></param>
    /// <param name="num"></param>
    public void SetItemById(int id, int num = 1)
    {
        this.id = id;
        InverntoryItem item = this.GetComponentInChildren<InverntoryItem>();
        item.SetIconById(id);
        countLabel.gameObject.SetActive(true);
        this.itemCount = num;
        countLabel.text = this.itemCount.ToString();
    }

    public void Clear()
    {
        id = 0;
        itemCount = 0;
        countLabel.gameObject.SetActive(false);
    }

    public int GetId()
    {
        return this.id;
    }

    public int GetCount()
    {
        return itemCount;
    }

    /// <summary>
    /// 捡到相同物品就加数量
    /// </summary>
    /// <param name="num"></param>
    public void AddCount(int num = 1)
    {
        this.itemCount += num;
        countLabel.text = itemCount.ToString();
    }

    public bool ReduceCount(int num = 1)
    {
        if (itemCount < num)
            return false;
        itemCount -= num;
        countLabel.text = itemCount.ToString();
        return true;
    }

    public void HideCountLabel()
    {
        countLabel.gameObject.SetActive(false);
    }

    public void ShowCountLabel()
    {
        countLabel.gameObject.SetActive(true);
    }
}
