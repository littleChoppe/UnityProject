using UnityEngine;
using System.Collections;

public class TankMovement : MonoBehaviour {

	// Use this for initialization
    public float MoveSpeed = 5;
    public float AngularSpeed = 100;
    public int TankNumber = 1;
    public AudioClip IdleAudio;
    public AudioClip DrivingAudio;

    private AudioSource audio;

   
	void Start () {
       audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float vertical = Input.GetAxis("VerticalPlayer" + TankNumber);
        transform.Translate(Vector3.forward * vertical * MoveSpeed * Time.deltaTime);
        float horizontal = Input.GetAxis("HorizontalPlayer" + TankNumber);
        transform.Rotate(Vector3.up * horizontal * AngularSpeed * Time.deltaTime);

        if (Mathf.Abs(vertical) > 0.1 || Mathf.Abs(horizontal) > 0.1)
        {
            audio.clip = DrivingAudio;
            if (audio.isPlaying == false)
                audio.Play();
        }
        else
        {
            audio.clip = IdleAudio;
            if (audio.isPlaying == false)
                audio.Play();
        }
	}
}
