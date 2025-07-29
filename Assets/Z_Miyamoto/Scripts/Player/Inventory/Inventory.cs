using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class Inventory : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddItem(ItemBase _item, int _amount)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            //同じアイテムを持ってたら個数を追加
            if (Container[i].Item == _item)
            {
                Container[i].Addamount(_amount);
                hasItem = true;
                break;
            }
        }
        //新しいアイテムを入手したら新しくスロットに追加
        if (!hasItem)
        {
            Container.Add(new InventorySlot(_item, _amount));
        }
    }
    [System.Serializable]
    public class InventorySlot
    {
        public ItemBase Item;
        public int amount;
        public InventorySlot(ItemBase _item, int _amount)
        {
            Item = _item;//アイテム
            amount = _amount;//個数
        }
        /// <summary>
        /// アイテムの個数を追加する
        /// </summary>
        /// <param name="value"></param>
        public void Addamount(int value)
        {
            amount += value;
        }
    }
}