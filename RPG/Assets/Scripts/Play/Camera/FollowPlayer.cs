using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    public float scrollSpeed = 10;
    public float rotateSpeed = 2;

    private Transform player;
    private Vector3 offset = Vector3.zero;
    private float distance = 0;
    private bool isRotate = false;
	void Start () 
    {
        player = GameObject.FindWithTag(Tags.Player).transform;
        offset = transform.position - player.position;
	}
	
	// Update is called once per frame
	void LateUpdate () 
    {
        transform.position = player.position + offset;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);

        if (Input.GetMouseButtonDown(1))
            isRotate = true;
        if (Input.GetMouseButtonUp(1))
            isRotate = false;

        if (isRotate)
        {
            RotateView();
        }

        //这个轴输出滚轮状态，
        //向前滚返回正直（拉近视野），
        //向后滚返回负值（拉远视野）
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            ScrollView();
        }
	}

    void ScrollView()
    {
        distance = offset.magnitude;
        distance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        distance = Mathf.Clamp(distance, 2f, 18f);
        offset = distance * offset.normalized;
    }

    void RotateView()
    {
        Debug.DrawLine(transform.position, player.position, Color.green);
        transform.RotateAround(player.position, player.up, rotateSpeed * Input.GetAxis("Mouse X"));

        Vector3 originalPos = transform.position;
        Quaternion originalRotation = transform.rotation;
        transform.RotateAround(player.position, transform.right, -rotateSpeed * Input.GetAxis("Mouse Y"));

        if (transform.eulerAngles.x < 10 || transform.eulerAngles.x > 80)
        {
            transform.position = originalPos;
            transform.rotation = originalRotation;
        }
        offset = transform.position - player.position;
    }
}
