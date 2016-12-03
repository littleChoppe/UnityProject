using UnityEngine;
using System.Collections;
using DG.Tweening;

public class GetStart : MonoBehaviour {

    public Vector3 myValue = Vector3.zero;
    public Transform Cube;
    public RectTransform taskPannel;
    private Vector3 myValue2;
    public float myValue3 = 0;

    void Start()
    {
        //这里使用C# Lambda 表达式，
        //第一个参数表示返回myValue的值，第二个参数是 DOTween 使用插值返回的值
        //第二个表达式代表把 DOTween 使用插值返回的值 x 赋值给 myValue,
        //第三个值是目标值
        //第四个值是 使用多少时间
        DOTween.To(() => myValue, x => myValue = x, new Vector3(10, 10, 10), 2);

        myValue2 = taskPannel.localPosition;
        DOTween.To(() => myValue2, x => myValue2 = x, Vector3.zero, 2);

        DOTween.To(() => myValue3, x => myValue3 = x, 10f, 2);
    }
	
    void Update()
    {
        Cube.position = myValue;
        taskPannel.localPosition = myValue2;
    }
}
