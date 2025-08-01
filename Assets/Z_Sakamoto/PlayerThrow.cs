using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerThrow : PlayerBase
{
    [SerializeField] private Transform _playerCamera;
    [SerializeField] private Transform _luggagePoint;
    [SerializeField] private float _throwTimeLimit;
    [SerializeField] private float _throwForce;
    [SerializeField] private float _throwUpwardForce;
    private float _throwTime;
    private PlayerStateManager _playerState;
    private void Awake()
    {
        base.BaseAwake(); // Awake‚ÅInputBuffer‚ðŠmŽÀ‚ÉŽæ“¾‚·‚é
        _playerState=GetComponent<PlayerStateManager>();
    }
    private void OnEnable()
    {
        _inputBuffer.ThrowAction.started += OnInputThrowTime;
        _inputBuffer.ThrowAction.canceled += OnInputThrowAction;
    }

    private void OnDisable()
    {
        _inputBuffer.ThrowAction.started -= OnInputThrowTime;
        _inputBuffer.ThrowAction.canceled -= OnInputThrowAction;
    }

    // Update is called once per frame
    void Update()
    {
        if (_inputBuffer.ThrowAction.IsPressed())
        {
            Debug.Log("‰Ÿ‚³‚ê‚½" + _throwTime);
        }
        if (_playerState.CurrentState == PlayerStateManager.PlayerState.carrying && _inputBuffer.ThrowAction.IsPressed())
        {
            _throwTime += Time.deltaTime;
            Debug.Log($"ThrowTime: {_throwTime}");
        }
    }
    private void OnInputThrowTime(InputAction.CallbackContext context)
    {
        if (_playerState.CurrentState == PlayerStateManager.PlayerState.carrying)
        {
            _throwTime = 0;
        }
    }
    private void OnInputThrowAction(InputAction.CallbackContext obj)
    {
        if (_playerState.CurrentState == PlayerStateManager.PlayerState.carrying 
            && _throwTime >= _throwTimeLimit)
        {
            Debug.Log("”­ŽË");
            Throw();
        }
        //_throwTime = 0;
    }
    private void Throw()
    {
        _luggage.transform.SetParent(null);
        Vector3 forceToAdd = _playerCamera.transform.forward * _throwForce
                           + transform.up * _throwUpwardForce;
        _luggageRb.AddForce(forceToAdd, ForceMode.Impulse);

        _luggage = null;
        _luggageRb = null;
        _playerState.CurrentState = PlayerStateManager.PlayerState.walking;
    }
}
