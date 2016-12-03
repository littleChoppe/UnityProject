using UnityEngine;
using System.Collections;
using DG.Tweening;

public class MyPannel : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        Tweener tweener = transform.DOLocalMoveX(0, 2);
        tweener.SetEase(Ease.OutBounce);
        //第一个参数是循环次数， 第二个参数是循环类型
        tweener.SetLoops(2, LoopType.Yoyo);
        //动画结束时进行播放
        tweener.OnComplete(TweenerComplete);
	}

    void TweenerComplete()
    {
        print("动画播放完了");
    }
}
