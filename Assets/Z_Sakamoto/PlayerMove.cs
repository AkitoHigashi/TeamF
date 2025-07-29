using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMove : PlayerBase
{
    [Header("move")]
    [SerializeField] private float _walkSpeed = 5f;
    [SerializeField] private float _sprintSpeed = 10f;
    private float _moveSpeed;

    [SerializeField] private Transform _playerCamera;
    private Vector2 _currentInput;
    private PlayerState _playerState;
    private InputBuffer _inputBuffer;
    private Rigidbody _rb;

    
    private void OnEnable()
    {
        _inputBuffer.MoveAction.performed += OnInputMove;
        _inputBuffer.MoveAction.canceled += OnInputMove;
        _inputBuffer.SprintAction.started += OnInputSprint;
    }
    private void OnDisable()
    {
        _inputBuffer.MoveAction.performed -= OnInputMove;
        _inputBuffer.MoveAction.canceled -= OnInputMove;
        _inputBuffer.SprintAction.started -= OnInputSprint;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _inputBuffer = FindAnyObjectByType<InputBuffer>();
    }

    // Update is called once per frame
    void Update()
    {
        StateHandler();
    }

    private void FixedUpdate()
    {
        Vector3 Orientation = _playerCamera.forward * _currentInput.y + _playerCamera.right * _currentInput.x;
        Vector3 velocity = Orientation.normalized * _moveSpeed;
        velocity.y = _rb.linearVelocity.y;
        _rb.linearVelocity = velocity;
        //âÒì]
        Vector3 forward = _playerCamera.forward;
        forward.y = 0; // è„â∫ÇÃåXÇ´Çñ≥éãÇµÇƒêÖïΩÇ»å¸Ç´ÇæÇØÇ…Ç∑ÇÈ
        if (forward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(forward);
        }
    }

    private void OnInputMove(InputAction.CallbackContext context)
    {
        _currentInput = context.ReadValue<Vector2>();
    }
    private void OnInputSprint(InputAction.CallbackContext context)
    {
        if (_playerState == PlayerState.walking)
        {
            _playerState = PlayerState.sprinting;
        }
        else
        {
            _playerState = PlayerState.walking;
        }
    }
    private void StateHandler()
    {
        switch (_playerState)
        {
            case PlayerState.walking:
                _moveSpeed = _walkSpeed;
                break;           
            case PlayerState.sprinting:
                _moveSpeed = _sprintSpeed;
                break;
        }
    }
}
