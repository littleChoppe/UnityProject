using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

    private PlayerMove playerMove;
    private Animation anim;
	void Start () 
    {
        playerMove = GetComponent<PlayerMove>();
        anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void LateUpdate () 
    {
        if (playerMove.GetPlayerState() == PlayerState.Idle)
        {
            PlayAnim("Idle");
        }
        else if (playerMove.GetPlayerState() == PlayerState.Moving)
        {
            PlayAnim("Run");
        }
	}

    void PlayAnim(string name)
    {
        anim.CrossFade(name);
    }
}
