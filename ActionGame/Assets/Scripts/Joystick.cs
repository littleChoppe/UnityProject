using UnityEngine;
using System.Collections;

public class Joystick : MonoBehaviour {

    public static float h = 0, v = 0;
    private bool isPress = false;
    private Transform core;
    private float moveRadius = 75f;

    void Start()
    {
        core = transform.FindChild("Core");
    }

    void OnPress(bool isPress)
    {
        this.isPress = isPress;
        if (isPress == false)
        {
            h = 0; v = 0;
            core.localPosition = Vector3.zero;
        }
    }
	
	void Update () 
    {
        if (isPress)
        {
            //以屏幕左下角为原点的坐标
            Vector2 touchPos = UICamera.lastEventPosition;
            //以图片中心为原点的坐标
            //图片大小为 182 * 182 中心点为 91，91
            touchPos -= new Vector2(91, 91);

            //限制移动范围
            float distance = Vector2.Distance(touchPos, Vector2.zero);
            if (distance > moveRadius)
            {
                touchPos = touchPos.normalized * moveRadius;
            }
            core.localPosition = touchPos;

            h = touchPos.x / moveRadius;
            v = touchPos.y / moveRadius;
        }
	}
}
