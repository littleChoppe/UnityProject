using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    public static MusicManager Instance;
    public AudioSource BgSound;

    public bool IsMute { get; private set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void InitMusic()
    {
        IsMute = false;
        BgSound.Play();
    }

    public void SwitchMusicState()
    {
        if (IsMute)
        {
            IsMute = false;
            MusicManager.Instance.BgSound.Play();
        }
        else
        {
            IsMute = true;
            MusicManager.Instance.BgSound.Pause();
        }
    }
    public void PlaySound(AudioClip clip, Transform emitter)
    {
        if (!IsMute)
        {
            GameObject go = new GameObject("Audio:" + clip.name);
            go.transform.position = emitter.position;
            AudioSource source = go.AddComponent<AudioSource>();
            source.clip = clip;
            source.Play();
            Destroy(go, clip.length);
            
        }
    }

    public void StopMusic()
    {
        IsMute = true;
        BgSound.Stop();
    }
}
