using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour {

	// Use this for initialization
    public float Speed;
    public GameObject ShellExplosionPrefabs;
    public AudioClip ShellExplosionAudio;

    private Rigidbody rigidbody;
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * Speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        GameObject.Instantiate(ShellExplosionPrefabs, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(ShellExplosionAudio, transform.position);
        Destroy(this.gameObject);

        if (collider.tag == "Tank")
            collider.SendMessage("ApplyDemage");
    }
}
