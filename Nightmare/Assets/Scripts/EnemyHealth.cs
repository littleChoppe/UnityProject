using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int HP = 100;

    private EnemyMove enemyMove;
    private CapsuleCollider collider;
    private Animator anim;
    private NavMeshAgent agent;
    private AudioSource source;
    private bool isDead = false;
    private float downSpeed = 0.1f;
    private ParticleSystem hitParticle;
    private SphereCollider trigger;
    public AudioClip DeathClip;

    void Awake()
    {
        enemyMove = GetComponent<EnemyMove>();
        collider = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        source = GetComponent<AudioSource>();
        trigger = GetComponent<SphereCollider>();
        hitParticle = GetComponentInChildren<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (isDead)
        {
            DisapearEnemy();
        }
	}

    public void TakeDemage(int demage, Vector3 hitPoint)
    {
        if (HP <= 0) return;
        source.Play();
        if (hitParticle != null)
            print("3");
        hitParticle.transform.position = hitPoint;
        hitParticle.Play();
        HP -= demage;
        if (HP <= 0)
            ToDie();

    }

    void ToDie()
    {
        AudioSource.PlayClipAtPoint(DeathClip, transform.position);
        agent.enabled = false;
        collider.enabled = false;
        trigger.enabled = false;
        enemyMove.enabled = false;
        isDead = true;
        anim.SetTrigger("Death");
    }

    void DisapearEnemy()
    {
        transform.Translate(Vector3.down * Time.deltaTime * downSpeed);
        if (transform.position.y < -3f)
            Destroy(gameObject);
    }
}
