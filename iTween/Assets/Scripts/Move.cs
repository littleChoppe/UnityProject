using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    private GameObject target;
    public float Time = 3;
    public iTween.EaseType easeType;
	void Start () 
    {
        target = GameObject.Find("Target");
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //第一种方法
            //moveto 3个参数的方法，参数分别为移动的物体， 移动的终点， 花费时间
            //itween.moveto(target, new vector3(6, 0, 0), 3);

            //第二种方法
            //哈希表中第一个参数是固定的，上官网查
            //第二个参数自己定义
            //Hashtable args = new Hashtable();
            //args.Add("x", 8);
            //args.Add("time", 4);
            //args.Add("delay", 1);   //动画延迟1秒开始

            //oncomplete 意思是当动画结束后，就会调用OnCompleteFunction这个名字的函数
            //args.Add("oncomplete", "OnCompleteFunction");

            //oncompletetarget 意思是当动画结束后调用的函数在后面参数的物体上
            //在这里也就是调用绑定这个脚本的物体上的OnCompleteFunction方法
            //args.Add("oncompletetarget", this.gameObject);

            //第三种方法
            //把参数成对写入
            //效果与上面的代码一样
            //Hashtable args = iTween.Hash("x", 8, "time", 4, "delay", 1,
            //    "oncomplete", "OnCompleteFunction", "oncompletetarget", this.gameObject);

            //移动效果参数
            //iTween 内置有移动效果的枚举类型
            Hashtable args = iTween.Hash("x", 3, "time", 2, "easetype", easeType);

            iTween.MoveTo(target, args);
        }
    }

    public void OnCompleteFunction()
    {
        print("end");
    }
	
}
