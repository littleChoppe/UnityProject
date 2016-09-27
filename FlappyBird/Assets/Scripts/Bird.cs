using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

    private float framePerSecond = 0.1f;
    private int frameCount = 0;
    private const int totalFrames = 3;
    //private float timer = 0;
    //private int frameCount = 0;
    //private int framePerSecond = 1;
    private MeshRenderer renderer;
	void Start () {
        renderer = gameObject.GetComponent<MeshRenderer>();
        StartCoroutine(BirdAnimation());
	}
	
	// Update is called once per frame
	void Update () {
        //BirdFlying();
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
            Debug.Log(new Vector2(1.0f / totalFrames * frameCount, 0));
            frameCount++;
            yield return new WaitForSeconds(Time.deltaTime / framePerSecond);
        }
    }
}
