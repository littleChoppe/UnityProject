using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuController : MonoBehaviour {

    public SkinnedMeshRenderer HeadMeshRender;
    public Mesh[] HeadArray;
    int headIndex = 0;

    public SkinnedMeshRenderer HandMeshRender;
    public Mesh[] HandArray;
    int handIndex = 0;

    public SkinnedMeshRenderer FootMeshRender;
    public Mesh[] FootArray;
    int footIndex = 0;

    public SkinnedMeshRenderer[] bodyRenders ;
    public Color Purple;
    int colorIndex = -1;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void OnHeadNextClick()
    {
        headIndex++;
        headIndex %= HeadArray.Length;
        HeadMeshRender.sharedMesh = HeadArray[headIndex];
    }

    public void OnHandNextClick()
    {
        handIndex++;
        handIndex %= HandArray.Length;
        HandMeshRender.sharedMesh = HandArray[handIndex];
    }

    public void OnFootNextnClick()
    {
        footIndex++;
        footIndex %= FootArray.Length;
        FootMeshRender.sharedMesh = FootArray[footIndex];
    }

    public void OnBuleButtonClick()
    {
        colorIndex = 0;
        OnColorSelect(Color.blue);
    }

    public void OnCyanButtonClick()
    {
        colorIndex = 1; colorIndex = 0;
        OnColorSelect(Color.cyan);
    }

    public void OnGreenButtonClick()
    {
        colorIndex = 2;
        OnColorSelect(Color.green);
    }

    public void OnPurpleButtonClick()
    {
        colorIndex = 3;
        OnColorSelect(Purple);
    }

    public void OnRedButtonClick()
    {
        colorIndex = 4;
        OnColorSelect(Color.red);
    }

    void OnColorSelect(Color color)
    {
        foreach (SkinnedMeshRenderer render in bodyRenders)
            render.material.color = color;
    }

    public void OnPlay()
    {
        SaveData();
        Application.LoadLevel(1);
    }

    void SaveData()
    {
        PlayerPrefs.SetInt("HeadIndex", headIndex);
        PlayerPrefs.SetInt("HandIndex", handIndex);
        PlayerPrefs.SetInt("FootIndex", footIndex);
        PlayerPrefs.SetInt("ColorIndex", colorIndex);
    }
}
