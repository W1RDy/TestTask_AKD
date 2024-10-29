using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CloseButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ClickAction);
    }

    private void ClickAction()
    {
        Application.Quit();
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(ClickAction);
    }
}
