﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float Speed = 4;
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
        if (transform.position.y >= 6f)
            Destroy(this.gameObject);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.SendMessage("BeHit");
            Destroy(gameObject);
        }
    }
}
