using UnityEngine;
using System.Collections;

public class Sphere : MonoBehaviour {

    private Vector3 targetPosition;
    private GameObject sphere;
    private float high = 4f;
    private float time = .7f;
	void Start () 
    {
        sphere = transform.FindChild("Sphere").gameObject;
        //使里面的小球向上下移动
        //这里需要注意如果使用的是 MoveTo, 那么小球不会随着父物体横向移动，
        //因为 iTween 修改的是世界坐标，使用MoveTo 只会让小球的世界坐标的 y 坐标等于5
        //使用MoveBy 的话相对运动，小球的y坐标相对之前坐标增加5
        iTween.MoveBy(sphere, iTween.Hash("time", time / 2, "y", 5,
            "easetype", iTween.EaseType.easeOutCubic));
        iTween.MoveBy(sphere, iTween.Hash("delay", time / 2, "time", time / 2, "y", -5,
            "easetype", iTween.EaseType.easeOutCubic));

        //外面整体横向移动
        iTween.MoveTo(this.gameObject, iTween.Hash("position", targetPosition, 
            "time", time, "easetype", iTween.EaseType.easeOutCubic));

        //使整体逐渐消失
        iTween.FadeTo(this.gameObject, iTween.Hash("delay", 3, "amount", 0,
            "time", 5, "oncomplete", "DestroySphere"));
	}

    public void DestroySphere()
    {
        Destroy(this.gameObject);
    }

    public void SetTargetPosition(Vector3 position)
    {
        targetPosition = position;
    }
}
