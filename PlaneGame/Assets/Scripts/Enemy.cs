using UnityEngine;
using System.Collections;

public enum EnemyType
{
    Small,
    Middle,
    Big,
}
public class Enemy : MonoBehaviour {

    public float HP = 1;
    public float Speed = 1;
    public int Score = 100;
    public EnemyType type;
    public AudioClip DieClip;
    public AudioClip BigPlaneClip;

    public Sprite[] DeathSprites;
    public Sprite[] HitSprites;
    public float RestHitTime = 0.2f;
    public float FrameCountPerSconds = 30;

    private float ScondPerFrame;
    private SpriteRenderer render;
    private float timer = 0;
    private float hitTimer = 0;
    private bool isDeath = false;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        ScondPerFrame = 1f / FrameCountPerSconds;
        if (type == EnemyType.Big)
            MusicManager.Instance.PlaySound(BigPlaneClip, this.transform);
        ButtonManager.Instance.BombButtonDown += UseBomb;
    }

	
	// Update is called once per frame
	void Update () 
    {
        Move();
        PlayAnimation();
	}

    void Move()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
        if (transform.position.y <= -7f)
            Destroy(gameObject);
    }
    void PlayAnimation()
    {
        if (hitTimer >= 0 && type != EnemyType.Small)
        {
            PlayHitAnimation(HitSprites);
        }

        if (isDeath)
        {
            PlayDeathAnimation(DeathSprites);
        }
    }
    void PlayHitAnimation(Sprite[] sprites)
    {
        hitTimer -= Time.deltaTime;
        int FrameCount = (int)((RestHitTime - hitTimer) / ScondPerFrame);
        int index = FrameCount % sprites.Length;
        render.sprite = sprites[index];
    }
    void PlayDeathAnimation(Sprite[] sprites)
    {
        timer += Time.deltaTime;
        int frameCount = (int)(timer / ScondPerFrame);

        if (frameCount >= sprites.Length)
        {
            MusicManager.Instance.PlaySound(DieClip, this.transform);
            Destroy(gameObject);
            timer = 0;
        }
        else
            render.sprite = sprites[frameCount];
    }

    public void BeHit()
    {
        //只要击中，如果是连续击中，就不断地颤动
        //只击中一次，只进行 RestHitTime 时长的颤动
        //最后颤动时间接近 0 最后一帧永远为正常状态
        hitTimer = RestHitTime;
        HP--;
        if (HP <= 0)
            ToDead();
    }

    void ToDead()
    {
        if (!isDeath)
        {
            isDeath = true;
            GameManager.Instance.AddScore(Score);
        }
    }

    void UseBomb()
    {
        ToDead();   
    }
}
