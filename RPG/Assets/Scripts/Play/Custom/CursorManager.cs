using UnityEngine;
using System.Collections;

public class CursorManager : MonoBehaviour {

    public static CursorManager Instance;

    public Texture2D AttackCursor;
    public Texture2D NormalCursor;
    public Texture2D NPCCursor;
    public Texture2D LookAtCursor;
    public Texture2D PickCursor;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void SetNormalCursor()
    {
        Cursor.SetCursor(NormalCursor, Vector2.zero, CursorMode.Auto);
    }

    public void SetNPCCorsor()
    {
        Cursor.SetCursor(NPCCursor, Vector2.zero, CursorMode.Auto);
    }
}
