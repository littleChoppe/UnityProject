using UnityEngine;
using System.Collections;

public class MinimapItem : MonoBehaviour {

    public string IconName;
    private GameObject iconItem;
    private Transform iconTransform;
    private Transform playerPosition;
	void Start () 
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        iconItem = Minimap.Instance.AddIcon(IconName);
        iconTransform = iconItem.transform;
	}

    void FixedUpdate()
    {
        Vector3 offset = transform.position - playerPosition.position;

        //3D环境以米为单位的目标位置
        Vector3 target3DPosition = new Vector3(offset.x, offset.z, 0);
        //2D环境以像素位单位，把3D转换成2D，这里100像素代表10米，因为背景图片宽为200像素，一半为100像素
        Vector3 target2DPosition = target3DPosition * 5;
        iconItem.transform.localPosition = target2DPosition;
    }

    void OnDestroy()
    {
        Destroy(iconItem);
    }
}
