using UnityEngine;
using System.Collections;
using DG.Tweening;

public class DOTweenAnimationPannel : MonoBehaviour {

    private DOTweenAnimation tweenAnimation;
    private bool isShow = false;
	void Start () 
    {
        tweenAnimation = GetComponent<DOTweenAnimation>();
	}

    public void OnClick()
    {
        if (isShow == false)
        {
            tweenAnimation.DOPlayForward();
            isShow = true;
        }
        else
        {
            tweenAnimation.DOPlayBackwards();
            isShow = false;
        }
    }
}
