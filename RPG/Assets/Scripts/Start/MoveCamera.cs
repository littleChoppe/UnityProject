using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

    public float Speed = 10f;
    private float EndZ = -20f;

	void Update () 
    {
        if (transform.position.z < EndZ)
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
	}
}
