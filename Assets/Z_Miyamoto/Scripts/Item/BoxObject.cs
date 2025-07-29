using UnityEngine;

[CreateAssetMenu(fileName = "New Box Object", menuName = "Inventory System/Items/Box")]
public class BoxObject : ItemBase
{
    public void Awake()
    {
        type = ItemType.Box;
    }
}
