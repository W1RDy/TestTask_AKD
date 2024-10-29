using UnityEngine;

public class DragSystem : MonoBehaviour
{
    Vector3 _rayOrigin = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    private DraggableObj _draggableObj;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.GetMouseButtonDown(0))
            {
                _draggableObj = GetDraggableObj();

                if (_draggableObj != null) _draggableObj.OnCursorDown();
            }

            if (_draggableObj != null) _draggableObj.OnCursorDrag();
        }

        if (Input.GetMouseButtonUp(0)) _draggableObj = null;
    }

    private DraggableObj GetDraggableObj()
    {
        var ray = Camera.main.ScreenPointToRay(_rayOrigin);
        Physics.Raycast(ray, out var hitInfo);

        if (hitInfo.collider != null)
        {
            hitInfo.collider.TryGetComponent(out DraggableObj component);
            if (component != null) return component;
        }

        return null;
    }
}