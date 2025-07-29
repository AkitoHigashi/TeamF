using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerThrow : MonoBehaviour
{
    private InputBuffer _inputBuffer;
    
    private void OnEnable()
    {
        _inputBuffer.ThrowAction.started += OnInputThrow;
        _inputBuffer.ThrowAction.canceled += OnInputThrow;

    }

    private void OnDisable()
    {
        _inputBuffer.ThrowAction.started -= OnInputThrow;
        _inputBuffer.ThrowAction.canceled -= OnInputThrow;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _inputBuffer = FindAnyObjectByType<InputBuffer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnInputThrow(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }
}
