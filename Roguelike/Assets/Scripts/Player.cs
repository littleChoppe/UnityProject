using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float restTime = 1;
    public int FoodConsume = 10;
    public int SodaConsume = 20;

    private float timer;
    private Vector2 targetPosition = new Vector2(1, 1);
    private Rigidbody2D rigidbody;
    private BoxCollider2D collider;
    private Animator animator;
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        rigidbody.MovePosition(targetPosition);
        timer += Time.deltaTime;
        if (timer < restTime) return;

        int horizontal = (int)Input.GetAxisRaw("Horizontal");
        int vertical = (int)Input.GetAxisRaw("Vertical");
        if (horizontal != 0)
        {
            vertical = 0;
        }

        if (horizontal != 0 || vertical != 0)
        {
            timer = 0;
            collider.enabled = false;
            RaycastHit2D hit = Physics2D.Linecast(targetPosition, targetPosition + new Vector2(horizontal, vertical));
            collider.enabled = true;
            if (hit.transform == null)
            {
                targetPosition += new Vector2(horizontal, vertical);
            }
            else
            {
                string itemName = hit.transform.tag;
                switch(itemName)
                {
                    case "OutWall":
                        break;

                    case "Wall":
                        animator.SetTrigger("Attack");
                        hit.collider.SendMessage("TakeDemage");
                        break;

                    case "Food":
                        GameManager.Instance.AddFood(FoodConsume);
                        targetPosition += new Vector2(horizontal, vertical);
                        Destroy(hit.collider.gameObject);
                        break;

                    case "Soda":
                        GameManager.Instance.AddFood(SodaConsume);
                        targetPosition += new Vector2(horizontal, vertical);
                        Destroy(hit.collider.gameObject);
                        break;
                }
            }
        }

	}
}
