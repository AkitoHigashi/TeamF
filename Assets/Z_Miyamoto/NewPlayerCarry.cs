using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerCarry : PlayerBase
{
    [SerializeField] private NewHand _hand;//矢嶋の手に持つオブジェクトと一緒にする
    [SerializeField] private Transform _luggagePosition;
    [SerializeField] private float _rayDistance = 5f;
    private GameObject _target;
    private PlayerData _playerData;
    private void Awake()
    {
        base.BaseAwake(); // AwakeでInputBufferを確実に取得する
        _playerData = GetComponent<PlayerData>();
    }
    private void OnEnable()
    {
        _inputBuffer.CarryAction.started += OnInputCarry;
    }
    private void OnDisable()
    {
        _inputBuffer.CarryAction.started -= OnInputCarry;
    }

    private void OnInputCarry(InputAction.CallbackContext context)
    {
        if (_playerData.CurrentState != PlayerData.PlayerState.carrying)
        {
            // カメラのビューポート中心からRayを生成
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            // Rayを飛ばして、何かに当たったら情報を取得
            if (Physics.Raycast(ray, out hit, _rayDistance))
            {
                _target = hit.collider.gameObject;
                //アイテムと荷物を両方持てるように
                if (_target.tag == "Luggage" || _target.tag == "Item")
                {
                    _hand.CatchItem(_target);
                    _playerData.Luggage = _target.gameObject;
                    _playerData.LuggageRb = _target.GetComponent<Rigidbody>();
                    _playerData.CurrentState = PlayerData.PlayerState.carrying;
                }
            }
            else
            {
                Debug.Log("Rayが何も拾いませんでした");
            }
        }
        else
        {
            _hand.ReleaseItem();
            _playerData.CurrentState = PlayerData.PlayerState.walking;
        }
    }
}