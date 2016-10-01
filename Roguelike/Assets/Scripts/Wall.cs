using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

    public int TotalHp = 2;
    public Sprite demageSprite;

    private SpriteRenderer render;
    private int currentHp;
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        currentHp = TotalHp;
    }

    void TakeDemage()
    {
        if (currentHp == TotalHp)
            render.sprite = demageSprite;
        currentHp -= 1;
        if (currentHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
