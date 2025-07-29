using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCarry : MonoBehaviour
{
    [SerializeField] private Transform _luggagePosition;
    private InputBuffer _inputBuffer;

    private void RegisterInputAction()
    {
        _inputBuffer.CarryAction.started += OnInputCarry;
        _inputBuffer.CarryAction.canceled += OnInputCarry;
    }

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _inputBuffer = FindAnyObjectByType<InputBuffer>();
        RegisterInputAction();
    }

    private void OnInputCarry(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }
}
