using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float Speed = 4f;
    private CharacterController cc;
    private Animator anim;
	void Start () 
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
	}
	
	void Update () 
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //虚拟杆控制优先
        if (Joystick.h != 0 || Joystick.v != 0)
        {
            h = Joystick.h;
            v = Joystick.v;
        }

        if (Mathf.Abs(h) > 0.1f || Mathf.Abs(v) > 0.1f)
        {
            anim.SetBool("Walk", true);

            //当按下攻击时又按下方向键， 在播放攻击动画时不应该行走
            //所以只有在播放行走动画时才能移动
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerRun"))
            {
                Vector3 dir = new Vector3(h, 0, v);
                transform.LookAt(dir + transform.position);
                cc.SimpleMove(transform.forward * Speed);
            }
        }
        else
        {
            anim.SetBool("Walk", false);
        }
	}
}
