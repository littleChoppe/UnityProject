using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TankLife : MonoBehaviour {

	// Use this for initialization
    public int hp = 100;
    public GameObject TankExplosionPrefab;
    public AudioClip TankExplosionAudio;

    public Slider hpSlider;

    private int currentHp;
	void Start () {
        currentHp = hp;
	}
	
	// Update is called once per frame
	void Update () {
	}

    void ApplyDemage()
    {
        if (currentHp <= 0) return;
        currentHp -= Random.Range(10, 20);
        hpSlider.value = (float)currentHp / hp;

        if (currentHp <= 0)
        {
            GameObject.Instantiate(TankExplosionPrefab, transform.position + Vector3.up, transform.rotation);
            AudioSource.PlayClipAtPoint(TankExplosionAudio, transform.position);
            Destroy(this.gameObject);
        }
    }
}
