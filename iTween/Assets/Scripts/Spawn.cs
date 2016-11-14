using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject SpherePrefabs;
    private Transform mousePointer;
	// Use this for initialization
	void Awake () 
    {
        mousePointer = GameObject.Find("MousePointer").transform;
	}
	
	// Update is called once per frame
	void Update () 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool isCollide = Physics.Raycast(ray, out hit);
        if (isCollide && hit.collider.tag == "Ground")
        {
            mousePointer.position = hit.point;
        }

        if (Input.GetMouseButtonDown(0))
            SpawnSphere();
	}

    void SpawnSphere()
    {
        GameObject instance = GameObject.Instantiate(SpherePrefabs, transform.position, Quaternion.identity) as GameObject;
        instance.GetComponent<Sphere>().SetTargetPosition(mousePointer.position);
    }
}
