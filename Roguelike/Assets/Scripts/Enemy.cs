using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public int LossFood = 10;

    private Vector2 targetPosition;
    private Rigidbody2D rigidbody;
    private Transform player;
    private Vector2 offset;
    private BoxCollider2D collider;
    private Animator animator;
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        targetPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        GameManager.Instance.EnemyList.Add(this);
	}

    void Update()
    {
        rigidbody.MovePosition(targetPosition);
    }
	
    public void Move()
    {
        offset = player.position - transform.position;
        if (offset.magnitude < 1.1)
        {
            animator.SetTrigger("Attack");
            AudioManager.Instance.EnemyAttack();
            player.SendMessage("TakeDemage", LossFood);
        }
        else
        {
            collider.enabled = false;
            RaycastHit2D hit = Physics2D.Linecast(transform.position, targetPosition + GetDirection(offset));
            collider.enabled = true;
            if (hit.transform == null)
            {
                targetPosition += GetDirection(offset);
            }
            else if (hit.collider.tag == "Food" || hit.collider.tag == "Soda")
            {
                targetPosition += GetDirection(offset);
            }
        }
    }

    private int ReturnOneStep(float number)
    {
        if (number > 0)
            return 1;
        else
            return -1;
    }

    private Vector2 GetDirection(Vector2 offset)
    {
        int x = 0, y = 0;
        Debug.Log(Mathf.Abs(offset.x)+ ", " + Mathf.Abs(offset.y));
        if (Mathf.Abs(offset.y) > Mathf.Abs(offset.x))
        {
            y = ReturnOneStep(offset.y);
        }
        else
        {
            x = ReturnOneStep(offset.x);
        }
        return new Vector2(x, y);
    }
}
