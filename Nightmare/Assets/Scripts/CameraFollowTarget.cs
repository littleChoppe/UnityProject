using UnityEngine;
using System.Collections;

public class CameraFollowTarget : MonoBehaviour
{

    private Vector3 offset;
    private Transform player;
    public float Smoothing = 3f;
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag(Tags.Player).transform;
        offset = transform.position - player.position;
	}
	
	// Update is called once per frame
	void LateUpdate () 
    {
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Smoothing);
	}
}
