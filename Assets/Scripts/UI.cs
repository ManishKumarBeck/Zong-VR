using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UI : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset _inputActions;

    private Canvas _canvas;
    private InputAction _menu;

    void Start()
    {
        _canvas = GetComponent<Canvas>();

        _canvas.enabled = false;

        _menu = _inputActions.FindActionMap("XRI LeftHand").FindAction("Menu");
        _menu.Enable();
        _menu.performed += ToggleMenu;



    }

    // Update is called once per frame
    private void OnDestroy()
    {
        _menu.performed -= ToggleMenu;
    }

    private void ToggleMenu(InputAction.CallbackContext context)
    {
        _canvas.enabled = !_canvas.enabled;
        
    }
}
