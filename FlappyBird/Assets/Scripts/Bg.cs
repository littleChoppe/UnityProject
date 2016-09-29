using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bg : MonoBehaviour {

	// Use this for initialization
    public Pipe[] Pipes = new Pipe[2];
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void ChangePipesPosition()
    {
        if (Pipes != null)
        {
            foreach (Pipe pipe in Pipes)
            {
                pipe.SendMessage("GenerateRandomPosition");
            }
        }
    }
}
