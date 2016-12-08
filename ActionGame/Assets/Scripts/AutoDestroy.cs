using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

    public float ExitTime = 1;
	void Start () 
    {
        Destroy(this.gameObject, ExitTime);
	}
	
}
