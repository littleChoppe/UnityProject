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
        if (GameManager.Instance.Food <= 0) return;
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
                MoveStep(horizontal, vertical);
            }
            else
            {
                HitSomething(hit, horizontal, vertical);
            }
            GameManager.Instance.ReduceFood(1);
            GameManager.Instance.OnPlayerMove();
        }

	}

    void HitSomething(RaycastHit2D hit, int horizontal, int vertical)
    {
        string itemName = hit.transform.tag;
        switch (itemName)
        {
            case "OutWall":
                break;

            case "Wall":
                animator.SetTrigger("Attack");
                hit.collider.SendMessage("TakeDemage");
                AudioManager.Instance.PlayerAttack();
                break;

            case "Food":
                GameManager.Instance.AddFood(FoodConsume);
                MoveStep(horizontal, vertical);
                Destroy(hit.collider.gameObject);
                AudioManager.Instance.EatFood();
                break;

            case "Soda":
                GameManager.Instance.AddFood(SodaConsume);
                MoveStep(horizontal, vertical);
                Destroy(hit.collider.gameObject);
                break;

            case "Enemy":
                break;
            case "Exit":
                MoveStep(horizontal, vertical);
                break;
        }
    }
    void MoveStep(int horizontal, int vertical)
    {
        targetPosition += new Vector2(horizontal, vertical);
        AudioManager.Instance.PlayerMove();
    }

    void TakeDemage(int lossFood)
    {
        animator.SetTrigger("Demage");
        GameManager.Instance.ReduceFood(lossFood);
    }
}
