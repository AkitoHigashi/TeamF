using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object",menuName = "Inventory System/Items/Default")]
public class DefaultObject : ItemBase
{
    public void Awake()
    {
        type = ItemType.Default;
    }
}
