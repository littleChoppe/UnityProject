using UnityEngine;
using System.Collections;

public class FollowBird : MonoBehaviour {

    private Transform birdTransform;
    private Vector3 offset;
    private float maxY = 2.4f;
    private float minY = -2.4f;
    private float minX = -6;
	void Start () {
        birdTransform = GameObject.FindGameObjectWithTag("Player").transform;
        offset = this.transform.position - birdTransform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 currentPosition = birdTransform.position + offset;
        if (currentPosition.y > maxY)
            currentPosition.y = maxY;
        if (currentPosition.y < minY)
            currentPosition.y = minY;
        if (currentPosition.x < minX)
            currentPosition.x = minX;
        this.transform.position = currentPosition;
	}
}
