using UnityEngine;
using System.Collections;
using DG.Tweening;

public class MyButton : MonoBehaviour {

    public RectTransform Pannel;
    private bool isIn = false;

    void Start()
    {
        //DOMove这个方法是DOTween的，不是Unity自带的
        //这个方法的意思是， 让Pannel从当前位置动画到Vector3.zero，用时1秒（修改的是世界坐标）
        //Pannel.DOMove(Vector3.zero, 1f);

        //每次调用 DO 方法都会生成一个 Tweener对象
        //Tweener对象保存着这个动画的信息
        //默认动画播放完就会销毁这个Tweener对象
        Tweener tweener = Pannel.DOLocalMove(Vector3.zero, 0.3f);

        //设置为不自动销毁
        tweener.SetAutoKill(false);

        //一开始不播放
        tweener.Pause();
    }

    public void OnClick()
    {
       if (isIn == false)
       {
           //Pannel.DOPlay();     //DOPlay 只会播放一次，会播放这个物体身上的所有动画
           Pannel.DOPlayForward();  //前放,会前放这个物体身上的所有动画
           isIn = true;
       }
        else
       {
           Pannel.DOPlayBackwards();    //后放，会后放这个物体身上的所有动画
           isIn = false;
       }
    }
}
