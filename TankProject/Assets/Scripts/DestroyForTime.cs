using UnityEngine;
using System.Collections;

public class DestroyForTime : MonoBehaviour {

	// Use this for initialization
    public float LifeTime;
	void Start () {
        Destroy(this.gameObject, LifeTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
