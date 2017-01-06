using UnityEngine;
using System.Collections;

public class Minimap : MonoBehaviour {

    private Camera minimapCamera;
    private Transform player;
	void Start () 
    {
        minimapCamera = GameObject.FindGameObjectWithTag(Tags.Minimap).GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag(Tags.Player).transform;
	}

    void LateUpdate()
    {
        minimapCamera.transform.position = new Vector3(player.position.x,
            minimapCamera.transform.position.y, player.position.z);
       
    }
    //放大
    public void OnZoomInClick()
    {
        minimapCamera.orthographicSize--;
    }

    public void OnZoomOutClick()
    {
        minimapCamera.orthographicSize++;
    }
}
