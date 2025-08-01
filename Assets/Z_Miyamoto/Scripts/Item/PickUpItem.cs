using TMPro;
using UnityEngine;

/// <summary>
/// プレイヤーの手にアイテムのプレハブを持たせる管理を行うクラス
/// </summary>
public class PickUpItem : MonoBehaviour
{
    public Transform HandTransform;
    private GameObject _heldObject;//今持っているオブジェクト

    /// <summary>
    /// アイテムを手に持つ
    /// </summary>
    /// <param name="item"></param>
    public void HoldItem(ItemBase item)
    {
        if (_heldObject != null)
        {
            Destroy(_heldObject);
        }
        _heldObject = Instantiate(item.Prefab, HandTransform);
        _heldObject.transform.localPosition = Vector3.zero;
        _heldObject.transform.localRotation = Quaternion.identity;
    }
    /// <summary>
    /// 手から離す（親子関係を解除してシーンに残す）
    /// </summary>
    public void RemoveHeldItem()
    {
        if (_heldObject != null)
        {
            _heldObject.transform.SetParent(null);
            _heldObject = null;
        }
    }
    /// <summary>
    /// 手持ちを完全にクリア（見た目も含めて破壊する）
    /// </summary>
    public void ClearHeldItem()
    {
        if (_heldObject != null)
        {
            Destroy(_heldObject);
            _heldObject = null;
        }
    }
}