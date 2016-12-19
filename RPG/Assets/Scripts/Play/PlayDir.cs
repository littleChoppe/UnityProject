using UnityEngine;
using System.Collections;

public class PlayDir : MonoBehaviour {

    public GameObject MouseEffect;
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool isHit = Physics.Raycast(ray, out hit);
            if (isHit && hit.collider.tag == Tags.Ground)
            {
                ShowMouseEffect(hit.point);
            }
        }
	}

    void ShowMouseEffect(Vector3 hitPoint)
    {
        hitPoint = new Vector3(hitPoint.x, hitPoint.y + 0.3f, hitPoint.z);
        GameObject.Instantiate(MouseEffect, hitPoint, Quaternion.identity);
    }
}
