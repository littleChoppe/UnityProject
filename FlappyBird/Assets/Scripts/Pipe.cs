using UnityEngine;
using System.Collections;

public class Pipe : MonoBehaviour {

    private float minY = -0.4f;
    private float maxY = -0.2f;
    private AudioSource audio;
	void Start () {
        audio = GetComponent<AudioSource>();
        GenerateRandomPosition();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

     void GenerateRandomPosition()
    {
        float posY = Random.Range(minY, maxY);
        this.transform.localPosition = new Vector3(this.transform.localPosition.x,
            posY, this.transform.localPosition.z);
    }

    void OnTriggerExit(Collider other)
     {
        if (other.tag == "Player")
        {
            audio.Play();
            GameManager.Instance.Score++;
        }
     }

    //test code
    void OnGUI()
    {
        GUILayout.Label("Score:" + GameManager.Instance.Score);
    }
}
