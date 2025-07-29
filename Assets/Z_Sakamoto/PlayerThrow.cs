using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerThrow : PlayerBase
{
    private void Awake()
    {
        BaseAwake(); //êeÇÃAwakeÇñæé¶ìIÇ…åƒÇ‘
    }
    private void OnEnable()
    {
        _inputBuffer.ThrowAction.started += OnInputThrow;
    }

    private void OnDisable()
    {
        _inputBuffer.ThrowAction.started -= OnInputThrow;
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
