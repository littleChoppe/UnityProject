using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

    public Transform Player1;
    public Transform Player2;

    private Vector3 offset;
    //private Camera camera;
    //private float distanceToSize;   //距离与视野大小的比例
    
	// Use this for initialization
	void Start () {
        //camera = GetComponent<Camera>();
        offset = transform.position - (Player1.position + Player2.position) / 2;
        //distanceToSize = camera.orthographicSize / Vector3.Distance(Player1.position, Player2.position);
	}
	
	// Update is called once per frame
	void Update () {
        if (Player1 == null || Player2 == null) return;
        transform.position = (Player1.position + Player2.position) / 2 + offset;
        //camera.orthographicSize = Vector3.Distance(Player1.position, Player2.position) * distanceToSize;
	}
}
