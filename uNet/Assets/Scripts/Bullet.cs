using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public int Demage = 10;
	void OnCollisionEnter(Collision col)
    {
        GameObject hit = col.gameObject;
        Health health = hit.GetComponent<Health>();
        if (health != null)
            health.TakeDemage(Demage);
        Destroy(this.gameObject);
    }
}
