using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

    private float maxY = 7f;
    private float minY = -3f;
    private float framePerSecond = 0.2f;
    private int frameCount = 0;
    private const int totalFrames = 3;
    private float horizontalSpeed = 2f;
    private float verticalSpeed = 5f;
    private Rigidbody rigidbody;
    private AudioSource audio;
    //private float timer = 0;
    //private int frameCount = 0;
    //private int framePerSecond = 1;
    private MeshRenderer renderer;
	void Start () {
        renderer = gameObject.GetComponent<MeshRenderer>();
        StartCoroutine(BirdAnimation());
        rigidbody = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        //BirdFlying();
       if (GameManager.Instance.currentGameState == GameState.Playing)
       {
           if (transform.position.y > maxY)
               transform.position = new Vector3(transform.position.x, maxY, transform.position.z);

           if (transform.position.y < minY)
               GameManager.Instance.currentGameState = GameState.Over;

           if (Input.GetMouseButton(0))
           {
               audio.Play();
               Vector3 vel = rigidbody.velocity;
               rigidbody.velocity = new Vector3(vel.x, verticalSpeed, vel.z);
           }
       }
	}

    //void BirdFlying()
    //{
    //    timer += Time.deltaTime;
    //    if (timer >= 1.0f / framePerSecond)
    //    {
    //        timer -= Time.deltaTime;
    //        frameCount++;
    //        int frameIndex = frameCount % 3;
    //        renderer.material.SetTextureOffset("_MainTex",
    //            new Vector2(0.33333f * frameIndex, 0));
    //    }
    //}

    IEnumerator BirdAnimation()
    {
        while (true)
        {
            if (frameCount % 3 == 0)
            {
                frameCount = 0;
            }
            renderer.material.SetTextureOffset("_MainTex",       //_MainTex : Main Texture
                new Vector2(1.0f / totalFrames * frameCount, 0));
            frameCount++;
            yield return new WaitForSeconds(Time.deltaTime / framePerSecond);
        }
    }

    void StartPlay()
    {
        rigidbody.useGravity = true;
        rigidbody.velocity = new Vector3(horizontalSpeed, 0, 0);
    }
}
