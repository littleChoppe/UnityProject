using UnityEngine;
using System.Collections;

public class MoveTrigger : MonoBehaviour {

	// Use this for initialization
    private Transform currentBg;
    private float bgDistance = 10.0f;
	void Start () {
        currentBg = this.transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Transform finalBg = GameManager.Instance.FinalBg;
            currentBg.position = new Vector3(finalBg.position.x + bgDistance, 
                currentBg.position.y, currentBg.position.z);
            currentBg.SendMessage("ChangePipesPosition");
            GameManager.Instance.FinalBg = currentBg;
        }
    }
}
