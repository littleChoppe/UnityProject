using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class TextColorTween : MonoBehaviour {

    private Text text;
	void Start () 
    {
        text = GetComponent<Text>();
        //第一个参数是目标颜色， 第二个参数是时间
        text.DOColor(Color.red, 1);

        //第一个参数是目标透明度， 第二个参数是时间
        text.DOFade(0, 1);
	}
}
