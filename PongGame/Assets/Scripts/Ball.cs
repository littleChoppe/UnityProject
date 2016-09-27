using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    private Rigidbody2D rigibody2D;
	void Start () {
        rigibody2D = GetComponent<Rigidbody2D>();
        GoBall();
	}

    void Update()
    {
        Vector2 velocity = rigibody2D.velocity;
        if ((velocity.x < 9 && velocity.x > -9) || (velocity.x > 10 || velocity.x < -10))
        {
            if (velocity.x > 0)
                velocity.x = 10f;
            else
                velocity.x = -10f;
        }
        rigibody2D.velocity = velocity;
        Debug.Log(rigibody2D.velocity.x);
    }
	
	// Update is called once per frame
	 void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player")
        {
            Vector2 velocity = rigibody2D.velocity;
            velocity.y = velocity.y / 2 + col.rigidbody.velocity.y / 2;
            rigibody2D.velocity = velocity;
        }

        if (col.gameObject.name == "RightWall" || col.gameObject.name == "LeftWall")
        {
            GameManager.Instance.ChangeScore(col.gameObject.name);
        }
    }

    void GoBall()
     {
         int number = Random.Range(0, 2);
         if (number == 1)
         {
             rigibody2D.AddForce(new Vector2(100, 0));
         }
         else
         {
             rigibody2D.AddForce(new Vector2(-100, 0));
         }
     }
    void ResetBall()
     {
        transform.position = Vector3.zero;
        GoBall();
     }
}
