using UnityEngine;
using System.Collections;

public class CrashPipe : MonoBehaviour {

    private AudioSource[] audios;

    void Start()
    {
        audios = GetComponents<AudioSource>();
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach(AudioSource audio in audios)
            {
                audio.Play();
            }
            GameManager.Instance.currentGameState = GameState.Over;
        }
    }
}
