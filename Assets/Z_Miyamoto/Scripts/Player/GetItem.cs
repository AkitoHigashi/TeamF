using UnityEngine;

public class GetItem : MonoBehaviour
{
    public Inventory2 Inventory;
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
            if (Inventory.InputToSlot(_currentItem.Item, 0))
            {
                Destroy(_currentItem.gameObject);
                _currentItem = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && _currentItem != null)
        {
            if (Inventory.InputToSlot(_currentItem.Item, 1))
            {
                Destroy(_currentItem.gameObject);
                _currentItem = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && _currentItem != null)
        {
            if (Inventory.InputToSlot(_currentItem.Item, 2))
            {
                Destroy(_currentItem.gameObject);
                _currentItem = null;
            }
        }
    }
}
