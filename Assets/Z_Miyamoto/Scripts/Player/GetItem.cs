using UnityEngine;

public class GetItem : MonoBehaviour
{
    public Inventory2 Inventory;
    public DisplayInventory DisplayInventory;
    private ItemInfo _currentItem;
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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && _currentItem != null)
        {
            GetCurrentItemToSlot(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && _currentItem != null)
        {
            GetCurrentItemToSlot(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && _currentItem != null)
        {
            GetCurrentItemToSlot(2);
        }
    }
    /// <summary>
    /// 指定された番号ごとのスロットに格納するメソッド
    /// </summary>
    /// <param name="slotIndex"></param>
    public void GetCurrentItemToSlot(int slotIndex)
    {
        if (_currentItem != null)
        {
            if (Inventory.InputToSlot(_currentItem.Item, slotIndex))
            {
                Destroy(_currentItem.gameObject);
                _currentItem = null;
                DisplayInventory.UpdateUI();//スロットにアイテムが入ったらUIを表示させる
            }
        }
    }
}
