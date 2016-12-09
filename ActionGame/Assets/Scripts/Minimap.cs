using UnityEngine;
using System.Collections;

public class Minimap : MonoBehaviour {

    public static Minimap Instance;
    private Transform playerIcon;
    public GameObject EnemyIconPrefabs;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        playerIcon = transform.Find("PlayerIcon");
    }

    public Transform GetPlayerIcon()
    {
        return playerIcon;
    }

    public Transform GetEnemyIcon(string tag)
    {
        GameObject enemy = NGUITools.AddChild(this.gameObject, EnemyIconPrefabs);
        if (tag == Tags.Boss)
        {
            enemy.GetComponent<UISprite>().spriteName = "BossIcon";
        }
        else if (tag ==Tags.Monster)
        {
            enemy.GetComponent<UISprite>().spriteName = "EnemyIcon";
        }
        return enemy.transform;
    }
}
