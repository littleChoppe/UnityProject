using UnityEngine;
using System.Collections;
using DG.Tweening;

public class MyShakeCamera : MonoBehaviour {

	void Start () 
    {
        //震动 1 秒
        //transform.DOShakePosition(1);

        //只在 XY 方向震动，若需要加强震动效果， 只要 new Vector3(3, 3, 0); 变大向量
        transform.DOShakePosition(1, new Vector3(1, 1, 0));
	}
	
}
