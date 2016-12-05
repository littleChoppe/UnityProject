using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float Speed = 4f;
    private CharacterController cc;
	void Start () 
    {
        cc = GetComponent<CharacterController>();
	}
	
	void Update () 
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (Mathf.Abs(h) > 0.1f || Mathf.Abs(v) > 0.1f)
        {
            Vector3 dir = new Vector3(h, 0, v);
            transform.LookAt(dir + transform.position);
            cc.SimpleMove(transform.forward * Speed);
        }
	}
}
