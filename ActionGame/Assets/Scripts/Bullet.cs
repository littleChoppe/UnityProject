using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float Speed = 10;
    public int Attack = 100;
	void Start () 
    {
        Destroy(this.gameObject, 3);
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == Tags.Boss || coll.tag == Tags.Monster)
            coll.GetComponent<ATKAndDemage>().TakeDemage(Attack);
    }
}
