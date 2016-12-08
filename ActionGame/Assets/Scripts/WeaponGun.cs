using UnityEngine;
using System.Collections;

public class WeaponGun : MonoBehaviour {

    public GameObject BulletPrefabs;
    public Transform BulletPosition;
    public int Attack = 100;

    public void Shoot()
    {
        GameObject go = GameObject.Instantiate(BulletPrefabs,
            BulletPosition.position, transform.root.rotation) as GameObject;
        go.GetComponent<Bullet>().Attack = Attack;

    }
}
