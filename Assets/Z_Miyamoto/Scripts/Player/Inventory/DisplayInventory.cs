using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// インベントリ内のスロット情報をUIに表示・更新するクラス。
/// </summary>
public class DisplayInventory : MonoBehaviour
{
    public Inventory Inventory;
    public Image[] SlotImages;

    /// <summary>
    /// スロットに入っているデータを参照してUIに表示する
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