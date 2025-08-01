using TMPro;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Transform handTransform;
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
        _heldObject = Instantiate(item.Prefab, handTransform);
        _heldObject.transform.localPosition = Vector3.zero;
        _heldObject.transform.localRotation = Quaternion.identity;
    }
    /// <summary>
    /// 手から離す
    /// </summary>
    public void RemoveHeldItem()
    {
        if (_heldObject != null)
        {
            Destroy(_heldObject);
        }
    }
}
