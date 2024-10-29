using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishSceneChecker : MonoBehaviour
{
    List<DraggableObj> _objects = new List<DraggableObj>();

    public event Action OnFinish;

    private bool CheckFinishCondition()
    {
        return _objects.Count == 9;
    }

    private void TryFinishScene()
    {
        if (CheckFinishCondition())
        {
            OnFinish?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DraggableObj draggableObj))
        {
            _objects.Add(draggableObj);
            TryFinishScene();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out DraggableObj draggableObj))
        {
            _objects.Remove(draggableObj);
        }
    }
}
