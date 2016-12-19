using UnityEngine;
using System.Collections;

public class CharacterCreation : MonoBehaviour {

    public GameObject[] CharacterPrefabs;
    private GameObject[] characterGameObjects;
    private int selectedIndex = 0;
    private int length = 0;
    private UIInput nameInput;
	void Start () 
    {
        length = CharacterPrefabs.Length;
        characterGameObjects = new GameObject[length];
        nameInput = GameObject.Find("InputName").GetComponent<UIInput>();
        for (int i = 0; i < length; i++)
        {
            characterGameObjects[i] = GameObject.Instantiate(CharacterPrefabs[i],
                transform.position, transform.rotation) as GameObject;
        }
        ShowCharacter();
	}

    void ShowCharacter()
    {
        characterGameObjects[selectedIndex].SetActive(true);
        for (int i = 0; i < length; i++)
        {
            if (i != selectedIndex)
            {
                characterGameObjects[i].SetActive(false);
            }
        }
    }

    public void OnNextButtonClick()
    {
        selectedIndex++;
        selectedIndex %= length;
        ShowCharacter();
    }

    public void OnPrevButtonClick()
    {
        selectedIndex--;
        if (selectedIndex == -1)
        {
            selectedIndex = length - 1;
        }
        ShowCharacter();
    }

    public void OnOKButtonClick()
    {
        SaveData();
        LoadGame();
    }

    void SaveData()
    {
        PlayerPrefs.SetInt("SelectedIndex", selectedIndex);
        PlayerPrefs.SetString("CharacterName", nameInput.value);
    }

    void LoadGame()
    {

    }
}