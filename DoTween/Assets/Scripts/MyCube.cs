using UnityEngine;
using System.Collections;
using DG.Tweening;

public class MyCube : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        //不加From时意思是从当前位置移动到 x = 5 的位置
        //添加 From 后意思是从 x = 5 的位置 移动到当前位置
        //transform.DOMoveX(5, 1).From();

        // From() 参数默认为 false 
        //为 True 时 意思是 从当前位置多 5 个单位的地方移动到当前位置
        //计算的是相对位置
        transform.DOMoveX(5, 1).From(true);

	
	}
}
