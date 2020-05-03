using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class mouse : MonoBehaviour
{
    private Vector2 cursorPos;

    public Camera cameraMain;
    private void Start()
    {
        Cursor.visible = false;
    }
void Update()
    {
        cursorPos = cameraMain.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
    }
}
