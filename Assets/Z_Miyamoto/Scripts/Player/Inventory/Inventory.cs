using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class Inventory : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddItem(ItemBase item, int amount)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            //同じアイテムを持ってたら個数を追加
            if (Container[i].Item == item)
            {
                Container[i].Addamount(amount);
                hasItem = true;
                break;
            }
        }
        //新しいアイテムを入手したら新しくスロットに追加
        if (!hasItem)
        {
            Container.Add(new InventorySlot(item, amount));
        }
    }
    [System.Serializable]
    public class InventorySlot
    {
        public ItemBase Item;
        public int Amount;
        public InventorySlot(ItemBase item, int amount)
        {
            Item = item;//アイテム
            Amount = amount;//個数
        }
        /// <summary>
        /// アイテムの個数を追加する
        /// </summary>
        /// <param name="value"></param>
        public void Addamount(int value)
        {
            Amount += value;
        }
    }
}