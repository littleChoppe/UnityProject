using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

    public AudioClip[] ChopSounds;
    public Sprite dmgSprite;
    public int hp = 4;

    private SpriteRenderer render;
	void Awake () 
    {
        render = GetComponent<SpriteRenderer>();
	}

    public void DemageWall(int loss)
    {
        SoundManager.Instance.RandomizeSfx(ChopSounds);
        render.sprite = dmgSprite;
        hp -= loss;
        if (hp <= 0)
            gameObject.SetActive(false);
    }
}
