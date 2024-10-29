using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObj : MonoBehaviour
{
    private Vector3 _mousePos;

    private Vector3 GetObjectScreenPos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        Debug.Log("MouseDown");
        _mousePos = Input.mousePosition - GetObjectScreenPos(); 
    }

    private void OnMouseDrag()
    {
        Debug.Log("MouseDrag");
        Debug.Log(GetObjectScreenPos());
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - _mousePos);
    }
}
