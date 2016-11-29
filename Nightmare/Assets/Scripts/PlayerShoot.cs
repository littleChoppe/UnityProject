using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    //每秒发多少子弹
    public float TimePerBullets = 0.15f;
    public int Attack = 30;
    private float timer = 0;
    private float effectDisplayTime = 0.2f;
    private ParticleSystem gunParticle;
    private Light light;
    private LineRenderer lineRender;
    public AudioSource source;
	void Start () 
    {
        gunParticle = GetComponentInChildren<ParticleSystem>();
        light = GetComponent<Light>();
        lineRender = GetComponent<LineRenderer>();
        source = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () 
    {
        timer += Time.deltaTime;
        if (Input.GetButton("Fire1") && timer >= TimePerBullets)
            Shoot();
        if (timer >= TimePerBullets * effectDisplayTime)
            ClearShootEffect();
	}

    void Shoot()
    {
        timer = 0;
        source.Play();
        gunParticle.Stop();
        gunParticle.Play();
        light.enabled = true;
        DisplayShootLine();
    }

    void ClearShootEffect()
    {
        light.enabled = false;
        lineRender.enabled = false;

    }

    void DisplayShootLine()
    {
        lineRender.enabled = true;
        //设置起点
        lineRender.SetPosition(0, transform.position);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        //碰到障碍物射线结束，否则射到100米以外
        if (Physics.Raycast(ray, out hit))
        {
            //设置终点
            lineRender.SetPosition(1, hit.point);
            if (hit.collider.tag == Tags.Enemy)
                hit.collider.GetComponent<EnemyHealth>().TakeDemage(Attack, hit.point);
        }
        else
        {
            //设置终点
            lineRender.SetPosition(1, transform.position + transform.forward * 100);
        }
    }
}
