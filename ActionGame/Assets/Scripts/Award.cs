using UnityEngine;
using System.Collections;

public enum AwardType
{
    Gun,
    DualSword,
}
public class Award : MonoBehaviour {

    public AwardType AwardKind;
    public float Speed = 8f;
    private Rigidbody rb;
    private bool startMove = false;
    private Transform player;
    public AudioClip AwardClip;

	void Start () 
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
	}
	
    void Update()
    {
        if (startMove)
        {
            transform.position = Vector3.Lerp(transform.position, player.position + Vector3.up, Speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, player.position + Vector3.up) < 0.5f)
            {
                player.GetComponent<PlayerAward>().GetAward(this.AwardKind);
                Destroy(this.gameObject);
                AudioSource.PlayClipAtPoint(AwardClip, transform.position, 1f);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == Tags.Ground)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            SphereCollider coll = this.GetComponent<SphereCollider>();
            coll.isTrigger = true;
            coll.radius = 2;
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == Tags.Player)
        {
            startMove = true;
            player = coll.transform;
        }
    }
}
