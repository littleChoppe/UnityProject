using UnityEngine;
using System.Collections;

public enum PlayerState
{
    Moving,
    Idle,
}
public class PlayerMove : MonoBehaviour {

    public float Speed = 4;

    private PlayerState state = PlayerState.Idle;
    private CharacterController cc;
    private PlayerDir dir;
    private bool isMoving = false;
	void Start () 
    {
        cc = GetComponent<CharacterController>();
        dir = GetComponent<PlayerDir>();
	}
	
	// Update is called once per frame
	void Update () 
    {
       if (Vector3.Distance(dir.GetTargetPosition(), transform.position) > 0.3f)
       {
           cc.SimpleMove(transform.forward * Speed);
           isMoving = true;
           state = PlayerState.Moving;
       }
        else
       {
           isMoving = false;
           state = PlayerState.Idle;
       }
	}

    public bool IsMoving()
    {
        return isMoving;
    }

    public PlayerState GetPlayerState()
    {
        return state;
    }
}
