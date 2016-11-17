using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    public float MoveSpeed = 2;
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 position = transform.position;
        if (position.y <= -11f)
        {
            position.y += 11 * 2;
            transform.position = position;
        }

        transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime);
	}
}
