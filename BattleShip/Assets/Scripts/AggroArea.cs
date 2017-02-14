using UnityEngine;
using System.Collections;

/// <summary>
/// 获取所有进入范围的对象
/// </summary>
public class AggroArea : MonoBehaviour {

    Unit parent;

    void Awake()
    {
        parent = transform.parent.GetComponent<Unit>();
    }

    void OnTriggerEnter(Collider co)
    {
        Unit target = co.GetComponentInParent<Unit>();
        if (target != null)
            parent.OnAggro(target);
    }

    void OnTriggerStay(Collider co)
    {
        Unit target = co.GetComponentInParent<Unit>();
        if (target)
            parent.OnAggro(target);
    }
}
