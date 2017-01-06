using UnityEngine;
using System.Collections;

public class DrugShopNPC : NPC {

    void OnMouseDown()
    {
        DrugShop.Instance.Show();
    }
}
