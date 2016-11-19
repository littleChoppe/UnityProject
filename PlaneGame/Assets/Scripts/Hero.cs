using UnityEngine;
using System.Collections;


public class Hero : MonoBehaviour {

    public enum WeaponType
    {
        Normal,
        Surper,
    }

    public Sprite[] Sprites;
    public int FrameCountPerSconds = 20;    //每秒播放多少帧
    public float MaxX = 2.5f;
    public float MaxY = 4.3f;
    public Gun GunTop;
    public Gun GunLeft;
    public Gun GunRight;
    public float RestAwardTime = 10f;
    public AudioClip DeathClip;

    private float awardTimer = 0;
    private WeaponType weaponType = WeaponType.Normal;
    private bool isIdle = true;
    private float timer = 0;
    private float ScondPerFrames;
    private SpriteRenderer render;
    private bool isMouseDown = false;
    private Vector3 lastMousePosition = Vector3.zero;

    void Awake()
    {
        render = GetComponent<SpriteRenderer>();
        ScondPerFrames = 1f / FrameCountPerSconds;
    }

    void Start()
    {
        GunTop.OpenFire();
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (GameManager.Instance.GetGameState() == GameState.Running)
        {
            PlayIdleAnimation();
            Control();
            ChangeWeapon();
        }
	}

    void PlayIdleAnimation()
    {
        if (isIdle)
        {
            timer += Time.deltaTime;    //总时间
            int FrameCount = (int)(timer / ScondPerFrames);     //这段时间播放的总帧数
            int index = FrameCount % 2;
            render.sprite = Sprites[index];
        }
        else
            timer = 0;
    }

    float CheckBorderLine(float toCheck, float Max)
    {
        if (toCheck > Max || toCheck < -Max)
        {
            if (toCheck > Max)
                return Max;
            else
                return -Max;
        }
        else
            return toCheck;
    }

    Vector3 CheckPosition(Vector3 position)
    {
        position.x = CheckBorderLine(position.x, MaxX);
        position.y = CheckBorderLine(position.y, MaxY);
        return position;
    }

    void Control()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
            lastMousePosition = Vector3.zero;
        }

        if (isMouseDown)
        {
            //Input.mousePosition 返回的坐标是以屏幕左下角为远点的
            //而世界坐标是以屏幕中心为远点的
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (lastMousePosition != Vector3.zero)
            {
                Vector3 offset = mousePosition - lastMousePosition;
                Vector3 position = transform.position;
                position += offset;
                transform.position = CheckPosition(position);
            }
            lastMousePosition = mousePosition;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Award")
        {
            GetAward(other.gameObject);
        }
        else if (other.gameObject.tag == "Enemy")
        {
            ToDie();
        }
    }

    void GetAward(GameObject awardObject)
    {
        Award award = awardObject.GetComponent<Award>();
        if (award != null)
        {
            MusicManager.Instance.PlaySound(award.GetAwardClip, this.transform);
            if (award.Type == AwardType.Bullet)
                awardTimer = RestAwardTime;

            else if (award.Type == AwardType.Bomb)
                BombManager.Instance.AddBomb();
        }
        Destroy(awardObject.gameObject);
    }

    void ToDie()
    {
        MusicManager.Instance.PlaySound(DeathClip, this.transform);
        MusicManager.Instance.SwitchMusicState();
        PlayDeathAnimation();
        GameManager.Instance.GameOver();
        Destroy(gameObject);
    }

    void PlayDeathAnimation()
    {

    }

    void ChangeWeapon()
    {
        if (awardTimer > 0)
        {
            awardTimer -= Time.deltaTime;
            if (weaponType == WeaponType.Normal)
                ChangeToSuperWeapon();
        }
        else
        {
            if (weaponType == WeaponType.Surper)
                ChangeToNormalWeapon();
        }
    }

    void ChangeToNormalWeapon()
    {
        weaponType = WeaponType.Normal;
        GunTop.OpenFire();
        GunLeft.StopFire();
        GunRight.StopFire();
    }

    void ChangeToSuperWeapon()
    {
        weaponType = WeaponType.Surper;
        GunTop.StopFire();
        GunLeft.OpenFire();
        GunRight.OpenFire();
    }
}
