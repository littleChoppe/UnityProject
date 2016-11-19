using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public GameObject Bullet;
    public float rate = 0.2f;   //生成子弹的频率，也就是每隔多久生成一个子弹

    void Fire()
    {
        GameObject.Instantiate(Bullet, transform.position, Quaternion.identity);
    }

    public void OpenFire()
    {
        //意思是1秒后调用 Fire 这个函数， 以后每隔 rate 秒调用一次
        InvokeRepeating("Fire", 1, rate);
    }

    public void StopFire()
    {
        CancelInvoke("Fire");     //这个函数会取消所有的Invoke
    }
}
