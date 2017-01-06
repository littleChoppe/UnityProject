using UnityEngine;
using System.Collections;

public class PlayerDir : MonoBehaviour {

    public GameObject MouseEffect;

    private bool isClickGround = false;
    private Vector3 target = Vector3.zero;
    private PlayerMove playerMove;

    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        target = transform.position;
    }
	void Update () 
    {
        //UICamera.Raycast(Input.mousePosition) 返回值是 bool ,如果鼠标在UI上返回true
        if (Input.GetMouseButtonDown(0) && !UICamera.Raycast(Input.mousePosition))
        {
            Vector3 hitPoint;
            if (IsClickGround(out hitPoint))
            {
                ShowMouseEffect(hitPoint);
                isClickGround = true;
                LookAtTarget(hitPoint);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isClickGround = false;
        }

        //在点击期间一直更新目标位置与朝向
        if (isClickGround)
        {
            Vector3 hitPoint;
            if (IsClickGround(out hitPoint))
            {
                LookAtTarget(hitPoint);
            }
        }
        //在行走其间一直根据目标位置更新朝向，
        //避免因斜坡的原因改变了朝向而一直到达不了终点
        else if (playerMove.IsMoving())
        {
            LookAtTarget(target);
        }
	}

    bool IsClickGround(out Vector3 hitPoint)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool isHit = Physics.Raycast(ray, out hit);
        hitPoint = hit.point;
        return isHit && (hit.collider.tag == Tags.Ground);
    }

    void LookAtTarget(Vector3 hitPoint)
    {
        target = new Vector3(hitPoint.x, transform.position.y, hitPoint.z);
        transform.LookAt(hitPoint);
    }

    void ShowMouseEffect(Vector3 hitPoint)
    {
        hitPoint = new Vector3(hitPoint.x, hitPoint.y + 0.3f, hitPoint.z);
        GameObject.Instantiate(MouseEffect, hitPoint, Quaternion.identity);
    }

    public Vector3 GetTargetPosition()
    {
        return target;
    }
}
