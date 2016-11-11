using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

    public GameManager GM;
    void Awake()
    {
        if (GameManager.Instance == null)
            Instantiate(GM);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
