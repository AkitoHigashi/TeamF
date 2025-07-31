using System.Collections.Generic;
using UnityEngine;
public class Inventory2 : MonoBehaviour
{
    public List<InventorySlot2> Container = new List<InventorySlot2>();
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
                Container.Add(new InventorySlot2(null));
            }
        }
    }
    /// <summary>
    ///アイテムを入手したら新しくスロットに追加するメソッド
    /// </summary>
    /// <param name="item"></param>
    public void AddItem(ItemBase item)
    {
        Container.Add(new InventorySlot2(item));
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
public class InventorySlot2
{
    public ItemBase Item;
    public InventorySlot2(ItemBase item)
    {
        Item = item;//アイテム
    }
}