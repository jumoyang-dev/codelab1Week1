using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderExpanded : MonoBehaviour
{
    Vector3 dragOffset;
    //store an offset when mousedown
    private void OnMouseDown()
    {
        dragOffset = transform.position - GetMousePos();
    }
    private void OnMouseDrag()
    {
        transform.position = GetMousePos() + dragOffset;
    }

    Vector3 GetMousePos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
