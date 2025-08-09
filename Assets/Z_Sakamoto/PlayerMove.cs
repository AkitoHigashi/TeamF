using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMove : PlayerBase
{
    [Header("move")]
    [SerializeField] private float _walkSpeed = 5f;
    [SerializeField] private float _sprintSpeed = 10f;
    private float _moveSpeed;

    [Header("Crouching")]
    [SerializeField] private float _crouchSpeed = 3f;
    //�A�j���[�V�����ł��ꍇ�͂���Ȃ��A�j���[�V�����ł������߂�����y����
    [SerializeField] private float _crouchYScale;
    private CapsuleCollider _collider;
    private float _startYScale;
    private Vector3 _startCenter;

    [Header("Jumping")] 
    [SerializeField] private float _jumpForce = 5f;
    
    private bool _isGround;

    [SerializeField] private Transform _playerCamera;
    private Vector2 _currentInput;
    private Rigidbody _rb;
    private PlayerData _playerData;

    
    private void OnEnable()
    {
        _inputBuffer.MoveAction.performed += OnInputMove;
        _inputBuffer.MoveAction.canceled += OnInputMove;
        _inputBuffer.SprintAction.started += OnInputSprint;
        _inputBuffer.CrouthAction.started += OnInputCrouth;
        _inputBuffer.JumpAction.started += OnInputJump;
    }

    


    private void OnDisable()
    {
        _inputBuffer.MoveAction.performed -= OnInputMove;
        _inputBuffer.MoveAction.canceled -= OnInputMove;
        _inputBuffer.SprintAction.started -= OnInputSprint;
        _inputBuffer.CrouthAction.started -= OnInputCrouth;
        _inputBuffer.JumpAction.started -= OnInputJump;
    }
    private void Awake()
    {
        base.BaseAwake(); // �e�N���X�̏������𖾎��I�ɌĂяo��
        _rb = GetComponent<Rigidbody>();
        _playerData=GetComponent<PlayerData>();
        _collider = GetComponent<CapsuleCollider>();
    }

    private void Start()
    {
        _startYScale = _collider.height;
        _startCenter = _collider.center;
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
        //��]
        Vector3 forward = _playerCamera.forward;
        forward.y = 0; // �㉺�̌X���𖳎����Đ����Ȍ��������ɂ���
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
        if (_playerData.CurrentState == PlayerData.PlayerState.walking)
        {
            _playerData.CurrentState = PlayerData.PlayerState.sprinting;
        }
        else
        {
            _playerData.CurrentState = PlayerData.PlayerState.walking;
        }
    }
    
    private void OnInputCrouth(InputAction.CallbackContext context)
    {
        //�J�v�Z���̏ꍇ
        if(_playerData.CurrentState != PlayerData.PlayerState.crouching)
        {
            _playerData.CurrentState= PlayerData.PlayerState.crouching;
            _collider.height = _crouchYScale;
            _collider.center = new Vector3(_startCenter.x, _crouchYScale / 2f, _startCenter.z);

            // �J�����ʒu�����������Ȃ炱���œ�����
            _playerCamera.localPosition += Vector3.down * 0.5f;
            if (_playerData.Luggage != null)
            {
                _playerData.Luggage.transform.SetParent(null);
            }
        }
        else
        {
            _playerData.CurrentState = PlayerData.PlayerState.walking;
            _collider.height = _startYScale;
            _collider.center = _startCenter;

            _playerCamera.localPosition += Vector3.up * 0.5f;
        }
    }
    
    private void OnInputJump(InputAction.CallbackContext obj)
    {
        if (_isGround)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isGround = false;
        }
    }
    private void StateHandler()
    {
        switch (_playerData.CurrentState)
        {
            case PlayerData.PlayerState.walking:
                _moveSpeed = _walkSpeed;
                break;           
            case PlayerData.PlayerState.sprinting:
                _moveSpeed = _sprintSpeed;
                break;
            case PlayerData.PlayerState.crouching:
                _moveSpeed= _crouchSpeed;
                break;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = true;
        }
    }
    
}
