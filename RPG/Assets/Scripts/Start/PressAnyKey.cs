using UnityEngine;
using System.Collections;

public class PressAnyKey : MonoBehaviour {

    private bool isAnyKeyDown = false;
    private GameObject buttonContainer;
	void Start () 
    {
        buttonContainer = transform.parent.Find("ButtonContainer").gameObject;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (isAnyKeyDown == false)
        {
            if (Input.anyKey && buttonContainer != null)
            {
                ShowButton();
            }
        }
	}

    void ShowButton()
    {
        buttonContainer.SetActive(true);
        gameObject.SetActive(false);
        isAnyKeyDown = true;
    }
}
