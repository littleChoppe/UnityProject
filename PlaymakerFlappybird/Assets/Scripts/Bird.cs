using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

    private Rigidbody2D rigidbody;
    private PlayMakerFSM fsm;
    private bool isGameOver = false;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        fsm = GetComponent<PlayMakerFSM>();
    }

    public void AddForce(Vector2 force)
    {
        Vector2 velocity = rigidbody.velocity;
        velocity.y = 0;
        rigidbody.velocity = velocity;
        rigidbody.AddForce(force);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (isGameOver)
            return;
        isGameOver = true;
        fsm.SendEvent("GameOver");
    }
}
