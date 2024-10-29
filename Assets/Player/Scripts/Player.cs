using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private MouseLook _mouseLook;

    [SerializeField] private FinishSceneChecker _finishSceneChecker;

    private void Awake()
    {
        Subscribe();
    }

    public void DeactivateControl()
    {
        _playerMovement.enabled = false;
        _mouseLook.enabled = false;
    }

    private void Subscribe()
    {
        _finishSceneChecker.OnFinish += DeactivateControl;
    }

    private void Unsubscribe()
    {
        _finishSceneChecker.OnFinish -= DeactivateControl;
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }
}
