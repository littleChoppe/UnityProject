using UnityEngine;
using System.Collections;

public class ItemControl : MonoBehaviour {

    float smoothing = 5f;
    float moveSpeed = 1f;
    public void ControlMove(Vector2 dir)
    {
        print(dir);
        Vector3 targetDir = new Vector3(dir.x, 0, dir.y);
        Vector3 targetPoint = targetDir + transform.position;
        this.transform.LookAt(targetPoint);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    public void Attack()
    {
        print("Attack!");
    }
}
