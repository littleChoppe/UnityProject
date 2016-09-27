using UnityEngine;
using System.Collections;

public class TankAttack : MonoBehaviour {

    public GameObject ShellPrefab;
    public KeyCode FireKey = KeyCode.Space;
    public AudioClip ShotAudio;

    private Transform firePoint;
	// Use this for initialization
	void Start () {
        firePoint = transform.Find("FirePoint");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(FireKey))
        {
            GameObject.Instantiate(ShellPrefab, firePoint.position, firePoint.rotation);
            AudioSource.PlayClipAtPoint(ShotAudio, firePoint.position);
        }
	}
}