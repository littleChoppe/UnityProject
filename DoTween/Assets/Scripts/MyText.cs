using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class MyText : MonoBehaviour {

    private Text text;
	void Start () 
    {
        text = GetComponent<Text>();
        //第一个参数是需要调用的文字
        //第二个参数是调用时间
        //显示为一个打字机效果
        text.DOText("DOTween 每次调用 DO 方法都会创建一个 Tweener 对象DOTween 每次调用 DO" + 
        "方法都会创建一个 Tweener 对象DOTween 每次调用 DO 方法都会创建一个 Tweener 对象", 10);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
