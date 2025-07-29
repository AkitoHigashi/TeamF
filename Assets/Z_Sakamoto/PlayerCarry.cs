using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCarry : PlayerBase
{
    [SerializeField] private Transform _luggagePosition;
    [SerializeField] private float _rayDistance=5f;
    private GameObject _target;
    private void OnEnable()
    {
        base.BaseAwake();
        _inputBuffer.CarryAction.started += OnInputCarry;
    }
    private void OnDisable()
    {
        _inputBuffer.CarryAction.started -= OnInputCarry;
    }  

    private void OnInputCarry(InputAction.CallbackContext context)
    {
        if (_playerState != PlayerState.carrying)
        {
            // カメラのビューポート中心からRayを生成
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            // Rayを飛ばして、何かに当たったら情報を取得
            if (Physics.Raycast(ray, out hit,_rayDistance))
            {
                _target = hit.collider.gameObject;
                if (_target.tag == ("Luggage"))
                {
                    _target.transform.SetParent(_luggagePosition);
                    _playerState = PlayerState.carrying;
                }
            }
            else
            {
                Debug.Log("Rayが何も拾いませんでした");
            }
        }else
        {
            _target.transform.SetParent(null);
            _playerState = PlayerState.walking;
        }
    }
}
