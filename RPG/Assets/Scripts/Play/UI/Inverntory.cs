using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inverntory : MonoBehaviour {

    public static Inverntory Instance;

    public List<InverntoryItemGrid> ItemGridList = new List<InverntoryItemGrid>();
    public UILabel coinLabel;
    public GameObject ItemPrefab;

    private TweenPosition tween;
    public int coin = 1000;
    private bool isShow = false;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        tween = this.GetComponent<TweenPosition>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PickUpItemById(Random.Range(2001, 2023));
        }
    }
    public void PickUpItemById(int id, int count = 1)
    {
        InverntoryItemGrid grid = SearchItemById(id);
        if (grid != null)
            grid.AddCount(count);
        else
        {
            //找到空的格子放，如果未满就放
            grid = SearchEmptyGrid();
            if (grid != null)
            {
                GameObject itemGo = NGUITools.AddChild(grid.gameObject, ItemPrefab);
                itemGo.GetComponent<InverntoryItem>().SetParent(grid);
                itemGo.transform.localPosition = Vector3.zero;
                grid.SetItemById(id, count);
            }
        }
    }

    /// <summary>
    /// 查找物品中是否存在物品,存在返回该物品，不存在返回空
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    InverntoryItemGrid SearchItemById(int id)
    {
        foreach (InverntoryItemGrid temp in ItemGridList)
        {
            if (temp.GetId() == id)
            {
                return temp;
            }
        }
        return null;
    }

    /// <summary>
    /// 找到空的方格，如果满了返回空
    /// </summary>
    /// <returns></returns>
    InverntoryItemGrid SearchEmptyGrid()
    {
        foreach (InverntoryItemGrid temp in ItemGridList)
        {
            if (temp.GetId() == 0)
            {
                return temp;
            }
        }
        return null;
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

    public void AddCoin(int count)
    {
        coin += count;
        coinLabel.text = coin.ToString();
    }

    public bool GetCoin(int count)
    {
        if (coin >= count)
        {
            coin -= count;
            coinLabel.text = coin.ToString();
            return true;
        }
        else
            return false;
    }
}
