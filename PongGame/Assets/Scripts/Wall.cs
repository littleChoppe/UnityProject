using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

    private AudioSource audio;
	void Start () {
        audio = GetComponent<AudioSource>();
	}

    void OnCollisionEnter2D()
    {
        audio.Play();
    }
}
