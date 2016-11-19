using UnityEngine;
using System.Collections;

public enum AwardType
{
    Bullet,
    Bomb,
}
public class Award : MonoBehaviour {

    public AwardType Type;
    public float Speed = 1.5f;
    public AudioClip GetAwardClip;
    public AudioClip SpawnClip;

    void Start()
    {
        MusicManager.Instance.PlaySound(SpawnClip, this.transform);
    }
	void Update () 
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
        if (transform.position.y <= -6)
            Destroy(gameObject);
	}
}
