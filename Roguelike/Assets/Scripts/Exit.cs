using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {
    void OnTriggerEnter2D()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
