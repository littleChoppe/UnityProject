using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

    void OnMouseEnter()
    {
        CursorManager.Instance.SetNPCCorsor();
    }

    void OnMouseExit()
    {
        CursorManager.Instance.SetNormalCursor();
    }

}
