using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float Speed = 5f;
    private Rigidbody rb;
    private Animator animator;
    private bool isMove = false;
    private LayerMask groundLayer;
	void Start () 
    {
        rb = gameObject.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        groundLayer = LayerMask.GetMask("Ground");
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        ControlDirection();
        Move();
        PlayAnimation();
        
	}

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //这个移动方法只会直接修改位置，忽略所有的物理效果
        //transform.Translate(new Vector3(horizontal, 0, vertical) * Speed * Time.deltaTime);
        if (horizontal != 0 || vertical != 0)
        {
            rb.MovePosition(this.transform.position + new Vector3(horizontal, 0, vertical) * Speed * Time.deltaTime);
            isMove = true;
        }
        else
        {
            isMove = false;
        }
    }

    void ControlDirection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 200, groundLayer))
        {
            Vector3 targetPosition = hit.point;
            targetPosition.y = transform.position.y;
            transform.LookAt(targetPosition);
        }
    }

    void PlayAnimation()
    {
        if (isMove)
            animator.SetTrigger("Move");
        else
            animator.SetTrigger("Idle");
    }

}
