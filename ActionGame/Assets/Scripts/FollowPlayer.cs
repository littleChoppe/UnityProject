using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    public float Speed = 1f; 
    private Vector3 offset = Vector3.zero;
    private Transform player;
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag(Tags.Player).transform;
        offset = this.transform.parent.position - player.position;
	}
	
	// Update is called once per frame
	void LateUpdate () 
    {
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Speed * Time.deltaTime);
        Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Speed * Time.deltaTime);
	}
}
