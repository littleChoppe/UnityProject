using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
    public KeyCode UpKey;
    public KeyCode DownKey;
    public float Speed = 10;

    private Rigidbody2D rigibody2d;
    private AudioSource audio;
	void Start () {
        rigibody2d = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(UpKey))
        {
            rigibody2d.velocity = new Vector2(0, Speed);
        }
        else if(Input.GetKey(DownKey))
        {
            rigibody2d.velocity = new Vector2(0, -Speed);
        }
        else
        {
            rigibody2d.velocity = new Vector2(0, 0);
        }
	
	}

    void OnCollisionEnter2D()
    {
        audio.pitch = Random.Range(0.8f, 1.2f);     //audio.pitch指的是音乐的播放速度，默认为1是正常速度
        audio.Play();
    }
}
