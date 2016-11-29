using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    public int HP = 100;
    private Animator anim;
    private PlayerMove playerMove;
    private PlayerShoot playerShoot;
    private float DeadTime = 3f;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMove>();
        playerShoot = GetComponentInChildren<PlayerShoot>();
    }
    public void TakeDemage(int demage)
    {
        if (HP <= 0)
            return;
        else
            HP -= demage;
        if (HP <= 0)
        {
            ToDie();
        }
    }

    void ToDie()
    {
        playerMove.enabled = false;
        playerShoot.enabled = false;
        anim.SetTrigger("Die");
        GameManager.Instance.GameOver(DeadTime);
    }
}
