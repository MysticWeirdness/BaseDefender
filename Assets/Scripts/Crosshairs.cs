using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshairs : MonoBehaviour
{
    public Texture2D crosshairsTexture;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotspot = new Vector2(16f, 16f);

    void Start()
    {
        StartCoroutine(SetInitialCursor());
    }

    private IEnumerator SetInitialCursor()
    {
        yield return null;
        Cursor.SetCursor(crosshairsTexture, hotspot, cursorMode);
    }
}
