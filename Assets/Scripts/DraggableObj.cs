using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObj : MonoBehaviour
{
    Vector3 _cameraCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    private Vector3 _mousePos;

    private Vector3 GetObjectScreenPos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    public void OnCursorDown()
    {
        _mousePos = _cameraCenter - GetObjectScreenPos(); 
    }

    public void OnCursorDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(_cameraCenter - _mousePos);
    }
}
