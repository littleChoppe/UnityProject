using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

    public float speed = 10;
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(h, 0 , v) * speed * Time.deltaTime);
    }

	void OnCollisionEnter(Collision coll)
    {
        Debug.Log("crash");
    }
}
