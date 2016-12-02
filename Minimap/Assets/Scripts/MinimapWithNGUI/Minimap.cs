using UnityEngine;
using System.Collections;

public class Minimap : MonoBehaviour {

    public static Minimap Instance;
    public GameObject IconPrefab;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public GameObject AddIcon(string iconName)
    {
        GameObject go = NGUITools.AddChild(this.gameObject, IconPrefab);
        go.GetComponent<UISprite>().spriteName = iconName;
        return go;
    }

}
