using UnityEngine;

public class FinishWindow : MonoBehaviour
{
    [SerializeField] private FinishSceneChecker _finishSceneChecker;
    [SerializeField] private GameObject _windowObj;

    private void Awake()
    {
        Subscribe();
    }

    private void ActivateWindow()
    {
        _windowObj.SetActive(true);
    }

    private void Subscribe()
    {
        _finishSceneChecker.OnFinish += ActivateWindow;
    }

    private void Unsubscribe()
    {
        _finishSceneChecker.OnFinish -= ActivateWindow;
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }
}