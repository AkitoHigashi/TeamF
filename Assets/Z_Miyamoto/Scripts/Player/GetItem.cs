using UnityEngine;

/// <summary>
/// 左クリックでアイテムを手に持つ・離す操作を行い、
/// 1～3キーでインベントリのスロットへの格納・取り出しを行う。
/// </summary>
public class GetItem : MonoBehaviour
{
    public Inventory Inventory;
    public DisplayInventory DisplayInventory;
    public PickUpItem PickUpItem;
    private ItemInfo _currentItem;        // 近くにある拾えるアイテムのGameObject情報
    private ItemBase _heldItem = null;       // 手に持っているアイテムのデータ
    private void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<ItemInfo>();
        if (item)
        {
            _currentItem = item;
            Debug.Log("キーを押してインベントリに格納してください");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var item = other.GetComponent<ItemInfo>();
        if (item)
        {
            _currentItem = null;
        }
    }
    /// <summary>
    /// 毎フレーム実行され、左クリックや数字キーの入力を検出し処理を振り分ける。
    /// </summary>
    private void Update()
    {
        HandleLeftClick();
        HandleNumberKeys();
    }
    /// <summary>
    /// 左クリック時の処理。手が空ならアイテムを手に持ち、持っていれば離す。
    /// </summary>
    private void HandleLeftClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_currentItem != null && _heldItem == null)
            {
                PickUpCurrentItem();
            }
            else if (_heldItem != null)
            {
                DropHeldItem();
            }
        }
    }
    /// <summary>
    /// 近くのアイテムを拾って手に持つ処理。
    /// </summary>
    private void PickUpCurrentItem()
    {
        _heldItem = _currentItem.Item;
        PickUpItem.HoldItem(_heldItem);

        Destroy(_currentItem.gameObject);
        _currentItem = null;

        DisplayInventory.UpdateUI();
        Debug.Log("アイテムを手に持ちました");
    }

    /// <summary>
    /// 手持ちのアイテムを離す処理。
    /// </summary>
    private void DropHeldItem()
    {
        PickUpItem.RemoveHeldItem();
        _heldItem = null;

        Debug.Log("アイテムを離しました");
    }
    /// <summary>
    /// 1～3キーの入力チェックを行い対応しているスロットの格納・取り出し処理を呼ぶ。
    /// </summary>
    private void HandleNumberKeys()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) HandleSlotKey(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) HandleSlotKey(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) HandleSlotKey(2);
    }

    /// <summary>
    /// 指定スロットインデックスに対応して、手持ちアイテムの格納またはスロットからの取り出しを行う。
    /// </summary>
    /// <param name="slotIndex"></param>
    private void HandleSlotKey(int slotIndex)
    {
        // スロット番号範囲チェック
        if (slotIndex < 0 || slotIndex >= Inventory.Container.Count)
        {
            Debug.LogWarning("スロット番号が範囲外です");
            return;
        }

        var slot = Inventory.Container[slotIndex];

        if (_heldItem != null)
        {
            // 手に持っているアイテムが既にそのスロットに入っている場合は格納禁止（二重持ち防止）
            if (slot != null && slot.Item == _heldItem)
            {
                Debug.Log("既にそのアイテムはスロットに入っています");
                return;
            }
            // スロットに別のアイテムが入っている場合は格納不可
            else if (slot != null && slot.Item != null)
            {
                Debug.LogWarning("そのスロットには別のアイテムが入っています。格納できません。");
                return;
            }
            else
            {
                // スロットが空なら手持ちアイテムを格納
                bool stored = Inventory.InputToSlot(_heldItem, slotIndex);
                if (stored)
                {
                    PickUpItem.ClearHeldItem(); // 手持ち表示オブジェクトを削除
                    _heldItem = null;
                    DisplayInventory.UpdateUI();
                    Debug.Log($"手持ちのアイテムをスロット{slotIndex + 1}に格納しました");
                    return;
                }
                else
                {
                    Debug.LogWarning("スロットへの格納に失敗しました");
                    return;
                }
            }
        }
        else
        {
            // 手が空ならスロットからアイテムを取り出して手に持つ
            if (slot != null && slot.Item != null)
            {
                _heldItem = slot.Item;
                PickUpItem.HoldItem(_heldItem);
                slot.Item = null;
                DisplayInventory.UpdateUI();
                Debug.Log($"スロット{slotIndex + 1}からアイテムを手に持ちました");
                return;
            }
            else
            {
                Debug.Log("手もスロットも空です。何もできません");
            }
        }
    }
}