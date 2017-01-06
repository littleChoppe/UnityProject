using UnityEngine;
using System.Collections;

public class DrugShop : MonoBehaviour {

    public static DrugShop Instance;
    private TweenPosition tween;
    private GameObject buyDialog;
    private UIInput buyNumberInput;
    private int buyID = 0;

    void  Awake()
    {
        if (Instance == null)
            Instance = this;
        tween = GetComponent<TweenPosition>();
        buyDialog = transform.Find("BuyNumberInput").gameObject;
        buyNumberInput = transform.Find("BuyNumberInput/InputField").GetComponent<UIInput>();
        buyDialog.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void Show()
    {
        tween.PlayForward();
        this.gameObject.SetActive(true);
    }

    public void OnCloseBtnDown()
    {
        tween.PlayReverse();
        this.gameObject.SetActive(false);
    }

    public void OnBuy1001Down()
    {
        BuyId(1001);
    }

    public void OnBuy1002Down()
    {
        BuyId(1002);
    }

    public void OnBuy1003Down()
    {
        BuyId(1003);
    }

    void BuyId(int id)
    {
        buyID = id;
        ShowBuyInputField();
    }

    public void OnOKBtnDown()
    {
        int count = int.Parse(buyNumberInput.value);
        if (count <= 0)
            return;
        ObjectInfor info = ObjectsInfor.Instance.GetObjectInfoById(buyID);
        int totalPrice = info.BuyPrice * count;
        bool success = Inverntory.Instance.GetCoin(totalPrice);
        if (success)
        {
            Inverntory.Instance.PickUpItemById(buyID, count);
        }
        else
        {

        }
        buyNumberInput.value = "0";
        buyDialog.SetActive(false);
    }

    void ShowBuyInputField()
    {
        buyDialog.SetActive(true);
        buyNumberInput.value = "0";
    }


}
