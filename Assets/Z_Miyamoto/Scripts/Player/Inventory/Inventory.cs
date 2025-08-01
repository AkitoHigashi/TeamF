using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// インベントリへの格納クラス
/// </summary>
public class Inventory : MonoBehaviour
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    private int _maxItemSlot = 3;

    /// <summary>
    /// スロットの初期化
    /// </summary>
    private void OnEnable()
    {
        if (Container.Count == 0)
        {
            for (int i = 0; i < _maxItemSlot; i++)
            {
                Container.Add(new InventorySlot(null));
            }
        }
    }
    /// <summary>
    /// 指定したアイテムを設定するメソッド
    /// </summary>
    /// <param name="item"></param>
    /// <param name="slotIndex"></param>
    /// <returns></returns>
    public bool InputToSlot(ItemBase item, int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < Container.Count)
        {
            if (Container[slotIndex].Item == null)
            {
                Container[slotIndex].Item = item;
                return true;
            }
            else
            {
                Debug.Log("ここのスロットには既にアイテムが入っています");
                return false;
            }
        }
        return false;
    }
}
[System.Serializable]
public class InventorySlot
{
    public ItemBase Item;
    public InventorySlot(ItemBase item)
    {
        Item = item;//アイテム
    }
}