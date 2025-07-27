using UnityEngine;

[CreateAssetMenu(fileName = "DefaultObject",menuName = "Inventory System/Items/Default")]
public class DefaultObject : ItemBase
{
    public void Awake()
    {
        type = ItemType.Default;
    }
}
