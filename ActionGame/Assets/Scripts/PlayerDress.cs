using UnityEngine;
using System.Collections;

public class PlayerDress : MonoBehaviour {

    public SkinnedMeshRenderer HeadMeshRender;
    public SkinnedMeshRenderer HandMeshRender;
    public SkinnedMeshRenderer FootMeshRender;
    public SkinnedMeshRenderer[] bodyRenders;
	void Start () 
    {
        InitDress();
	}

    void InitDress()
    {
        int headIndex = PlayerPrefs.GetInt("HeadIndex");
        int handIndex = PlayerPrefs.GetInt("HandIndex");
        int footIndex = PlayerPrefs.GetInt("FootIndex");
        int colorIndex = PlayerPrefs.GetInt("ColorIndex");
        Color color = MenuController.Instance.ColorArray[colorIndex];

        HeadMeshRender.sharedMesh = MenuController.Instance.HeadArray[headIndex];
        HandMeshRender.sharedMesh = MenuController.Instance.HandArray[handIndex];
        FootMeshRender.sharedMesh = MenuController.Instance.FootArray[footIndex];

        foreach (SkinnedMeshRenderer render in bodyRenders)
            render.material.color = color;
    }
}
