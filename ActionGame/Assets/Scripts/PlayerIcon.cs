using UnityEngine;
using System.Collections;

public class PlayerIcon : MonoBehaviour {

    private Transform playerIcon;
 
    void Start()
    {
        playerIcon = Minimap.Instance.GetPlayerIcon();
    }

    void Update()
    {
        float y = transform.eulerAngles.y;
        playerIcon.localEulerAngles = new Vector3(0, 0, -y);
    }
}
