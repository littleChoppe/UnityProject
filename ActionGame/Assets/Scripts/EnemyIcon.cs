using UnityEngine;
using System.Collections;

public class EnemyIcon : MonoBehaviour {

    private Transform icon;
    private Transform player;
	void Start () 
    {
        icon = Minimap.Instance.GetEnemyIcon(this.tag);
        player = GameObject.FindGameObjectWithTag(Tags.Player).transform;
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 offset = transform.position - player.position;
        offset *= 10;
        icon.localPosition = new Vector3(offset.x, offset.z, 0);
	}

    void OnDestroy()
    {
        if (icon != null)
            Destroy(icon.gameObject);
    }
}
