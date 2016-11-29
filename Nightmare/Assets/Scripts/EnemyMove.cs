using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

    private NavMeshAgent agent;
    private Transform player;
    private Animator anim;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag(Tags.Player).transform;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Vector3.Distance(transform.position, player.position) <= agent.stoppingDistance)
            anim.SetTrigger("Idle");
        else
        {
            anim.SetTrigger("Move");
            agent.SetDestination(player.position);
        }

	}
}
