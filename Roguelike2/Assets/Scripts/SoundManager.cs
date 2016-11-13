using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	// Use this for initialization
    public AudioSource EfxSource;
    public AudioSource BgSource;

    public static SoundManager Instance = null;

    public float LowPitchRange = .95f;
    public float HighPichRange = 1.0f;
	void Awake () 
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
	}

    public void PlaySingle(AudioClip clip)
    {
        EfxSource.clip = clip;
        EfxSource.Play();
    }

    public void RandomizeSfx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(LowPitchRange, HighPichRange);

        EfxSource.pitch = randomPitch;
        EfxSource.clip = clips[randomIndex];
        EfxSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
