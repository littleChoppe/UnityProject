using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get { return _instance; }
    }

    public float minPitch = .9f;
    public float maxPitch = 1.1f;
    public AudioClip[] PlayerMoveClip;
    public AudioClip[] PlayerAttackClip;
    public AudioClip[] EatFoodClip;
    public AudioClip[] DrinkSodaClip;
    public AudioClip[] EnemyAttackClip;
    public AudioClip PlayerDieClip;


    public AudioSource efxSource;
    public AudioSource bgSource;

    public
    void Awake()
    {
        _instance = this;
    }

    private void PlayRandomMusic(params AudioClip[] clips)
    {
        float clip = Random.Range(minPitch, maxPitch);
        int index = Random.Range(0, clips.Length);
        efxSource.clip = clips[index];
        efxSource.Play();
    }

    public void PlayerMove()
    {
        PlayRandomMusic(PlayerMoveClip);
    }

    public void PlayerAttack()
    {
        PlayRandomMusic(PlayerAttackClip);
    }

    public void EatFood()
    {
        PlayRandomMusic(EatFoodClip);
    }

    public void DrinkSoda()
    {
        PlayRandomMusic(DrinkSodaClip);
    }
    public void EnemyAttack()
    {
        PlayRandomMusic(EnemyAttackClip);
    }

    public void PlayerDie()
    {
        PlayRandomMusic(PlayerDieClip);
    }
    public void StopBgMusic()
    {
        bgSource.Stop();
    }
}
