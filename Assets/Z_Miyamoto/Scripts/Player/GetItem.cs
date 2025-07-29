using UnityEngine;

public class GetItem : MonoBehaviour
{
    public Inventory inventory;

    private void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<ItemInfo>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }
}
