using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    public GameObject BulletPrefab;
    public Transform ShootPoint;
	void Update () 
    {
        //如果不是本地角色则不调用下面代码
        //没有了这个判断，下面的控制会控制所有角色
        if (isLocalPlayer == false)
            return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up * h * 120 * Time.deltaTime);
        transform.Translate(Vector3.forward * v * 3 * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }
	}

    public override void OnStartLocalPlayer()
    {
        //这个方法只会在本地角色那里调用 当角色被创建的时候
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    //注意：使用了下面这个标识的函数 开头要是 Cmd
    [Command]   //这个标识表示：在客户端调用，在服务器运行
    void CmdFire()  //这个方法需要在服务器上调用
    {
        //子弹的生成需要在服务器上完成，然后同步到各个客户端
        GameObject bullet = Instantiate(BulletPrefab, ShootPoint.position, ShootPoint.rotation) as GameObject;
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 10;
        Destroy(bullet, 2);

        //这个方法表示在各个客户端生成这个物体
        //由于使用Command标识，所以上面的代码是在服务器上生成子弹的
        //下面这个调用会在各个客户端上生成这个物体
        NetworkServer.Spawn(bullet);
    }
}
