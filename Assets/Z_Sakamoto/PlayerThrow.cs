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
    private PlayerData _playerData;
    private void Awake()
    {
        base.BaseAwake(); // Awake‚ÅInputBuffer‚ðŠmŽÀ‚ÉŽæ“¾‚·‚é
        _playerData=GetComponent<PlayerData>();
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
        if (_playerData.CurrentState == PlayerData.PlayerState.carrying && _inputBuffer.ThrowAction.IsPressed())
        {
            _throwTime += Time.deltaTime;
            Debug.Log($"ThrowTime: {_throwTime}");
        }
    }
    private void OnInputThrowTime(InputAction.CallbackContext context)
    {
        if (_playerData.CurrentState == PlayerData.PlayerState.carrying)
        {
            _throwTime = 0;
        }
    }
    private void OnInputThrowAction(InputAction.CallbackContext obj)
    {
        if (_playerData.CurrentState == PlayerData.PlayerState.carrying 
            && _throwTime >= _throwTimeLimit)
        {
            Debug.Log("”­ŽË");
            Throw();
        }
        //_throwTime = 0;
    }
    private void Throw()
    {
        GameObject luggage = _playerData.Luggage;
        Rigidbody rb = _playerData.LuggageRb;
        if (luggage == null || rb == null) return;
        luggage.transform.SetParent(null);

        Vector3 forceToAdd = _playerCamera.transform.forward * _throwForce
                           + transform.up * _throwUpwardForce;
        rb.AddForce(forceToAdd, ForceMode.Impulse);

        _playerData.Luggage = null;
        _playerData.LuggageRb = null;
        _playerData.CurrentState = PlayerData.PlayerState.walking;
    }
}
