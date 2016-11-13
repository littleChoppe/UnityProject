using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MovingObject {

    public int wallDamage = 1;
    public int pointsPerFood = 10;
    public int pointsPerSoda = 20;
    public float restartLevelDelay = 1f;
    public Text FoodText;
    public AudioClip[] MoveSounds;
    public AudioClip[] EatSounds;
    public AudioClip[] DrinkSounds;
    public AudioClip GameOverSound;

    private Animator animator;
    private int food;

    //控制移动端
    private Vector2 touchOrigin = -Vector2.one; //基类触摸的起始位置，初始化为屏幕外一点
    protected override void Start()
    {
        animator = GetComponent<Animator>();
        food = GameManager.Instance.PlayerFoodPoints;

        FoodText.text = "Food : " + food;
        base.Start();
    }

    //在人物消失时自动调用
    private void OnDisable()
    {
        GameManager.Instance.PlayerFoodPoints = food;
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (!GameManager.Instance.playersTurn) return;

        int horizontal = 0;
        int vertical = 0;

#if UNITY_STANDALONE || UNITY_WEBPLAYER
        horizontal = (int)Input.GetAxisRaw("Horizontal");
        vertical = (int)Input.GetAxisRaw("Vertical");

        if (horizontal != 0)
            vertical = 0;
#else
        if (Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];
            if (myTouch.phase == TouchPhase.Began)  //判断是否为触摸起点
            {
                touchOrigin = myTouch.position;
            }
                //判断是否为触摸动作结束，也就是手指离开屏幕
                //touchOrigin.x >= 0 意味着触摸点在屏幕范围内，touchOrigin 值也发生改变，且触摸结束
            else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
            {
                Vector2 touchEnd = myTouch.position;
                float x = touchEnd.x - touchOrigin.x;
                float y = touchEnd.y - touchOrigin.y;
                touchOrigin.x = -1; //防止重复判断

                //判断是偏向横向还是竖向滑动
                if (Mathf.Abs(x) > Mathf.Abs(y))
                    horizontal = x > 0 ? 1 : -1;
                else
                    vertical = y > 0 ? 1 : -1;
            }
        }
#endif

        if (horizontal != 0 || vertical != 0)
            AttempMove<Wall>(horizontal, vertical);
	}

    protected override void AttempMove<T>(int xDir, int yDir)
    {
        food--;
        FoodText.text = "Food : " + food;
        base.AttempMove<T>(xDir, yDir);
        RaycastHit2D hit;
        if (Move(xDir, yDir , out hit))
        {
            SoundManager.Instance.RandomizeSfx(MoveSounds);
        }
        CheckIfGameOver();

        GameManager.Instance.playersTurn = false;
    }

    protected override void OnCantMove<T>(T component)
    {
        Wall hitWall = component as Wall;
        hitWall.DemageWall(wallDamage);
        animator.SetTrigger("PlayerChop");
    }

    private void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void LossFood(int loss)
    {
        animator.SetTrigger("PlayerHit");
        food -= loss;
        FoodText.text = "-" + loss + " Food : " + food;
        CheckIfGameOver();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Exit")
        {
            Invoke("Restart", restartLevelDelay);
            enabled = false;
        }
        else if (other.tag == "Food")
        {
            food += pointsPerFood;
            FoodText.text = "+" + pointsPerFood + " Food : " + food;
            SoundManager.Instance.RandomizeSfx(EatSounds);
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Soda")
        {
            food += pointsPerSoda;
            FoodText.text = "+" + pointsPerSoda + " Food : " + food;
            SoundManager.Instance.RandomizeSfx(DrinkSounds);
            other.gameObject.SetActive(false);
        }
    }

    private void CheckIfGameOver()
    {
        if (food <= 0)
        {
            SoundManager.Instance.PlaySingle(GameOverSound);
            SoundManager.Instance.BgSource.Stop();
            GameManager.Instance.GameOver();
        }
    }
}
