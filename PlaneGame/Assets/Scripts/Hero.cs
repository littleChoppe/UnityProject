using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

    public Sprite[] Sprites;
    public int FrameCountPerSconds = 20;    //每秒播放多少帧
    public float MaxX = 2.5f;
    public float MaxY = 4.3f;

    private bool isAnimation = true;
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
	
	// Update is called once per frame
	void Update () 
    {
        PlayAnimation();
        Control();
	}

    void PlayAnimation()
    {
        if (isAnimation)
        {
            timer += Time.deltaTime;    //总时间
            int FrameCount = (int)(timer / ScondPerFrames);     //这段时间播放的总帧数
            int index = FrameCount % 2;
            render.sprite = Sprites[index];
        }
        else
        {
            timer = 0;
        }
    }

    float CheckBorderLine(float toCheck, float Max)
    {
        return toCheck > Max ? Max : (toCheck < -Max ? -Max : toCheck);
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
                position.x = CheckBorderLine(position.x, MaxX);
                position.y = CheckBorderLine(position.y, MaxY);
                transform.position = position;
            }
            lastMousePosition = mousePosition;
        }
    }
}
