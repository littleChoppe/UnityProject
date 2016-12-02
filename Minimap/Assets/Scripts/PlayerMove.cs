using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float Speed = 5f;

	void Update () 
    {
        Move();
	}

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(h, 0, v) * Speed * Time.deltaTime);
    }
}
