using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BombManager : MonoBehaviour {
    public static BombManager Instance;

    private int count = 2;
    private Text bombText;
    public AudioClip BombClip;
    void Awake()
    {
        Instance = this;
        bombText = transform.FindChild("BombText").GetComponent<Text>();
        bombText.text = "X " + count;
    }

    public void AddBomb()
    {
        count++;
        bombText.text = "X " + count; 
    }

    public bool ConsumeBomb()
    {
        if (count > 0 && GameManager.Instance.GetGameState() == GameState.Running)
        {
            count--;
            bombText.text = "X " + count;
            MusicManager.Instance.PlaySound(BombClip, this.transform);
            return true;
        }
        else
            return false;
    }
}
