using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCarry : MonoBehaviour
{
    [SerializeField] private Transform _luggagePosition;
    private InputBuffer _inputBuffer;

    private void OnEnable()
    {
        _inputBuffer.CarryAction.started += OnInputCarry;
        _inputBuffer.CarryAction.canceled += OnInputCarry;
    }
    private void OnDisable()
    {
        _inputBuffer.CarryAction.started -= OnInputCarry;
        _inputBuffer.CarryAction.canceled -= OnInputCarry;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _inputBuffer = FindAnyObjectByType<InputBuffer>();
    }

    private void OnInputCarry(InputAction.CallbackContext context)
    {
        
    }
}
