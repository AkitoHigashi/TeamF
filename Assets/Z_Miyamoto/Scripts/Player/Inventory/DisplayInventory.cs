using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public Inventory2 Inventory;
    public Image [] SlotImages;

    /// <summary>
    /// スロットに入っているデータを参照してUIに表示するためのメソッド
    /// </summary>
    public void UpdateUI()
    {
        for (int i = 0; i < SlotImages.Length; i++)
        {
            if (Inventory.Container.Count > i && Inventory.Container[i] != null && Inventory.Container[i].Item != null)
            {
                SlotImages[i].sprite = Inventory.Container[i].Item.Icon;
                SlotImages[i].enabled = true;
            }
            else
            {
                SlotImages[i].sprite = null;
                SlotImages[i].enabled = false;
            }
        }
    }
}
