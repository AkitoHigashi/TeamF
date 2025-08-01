using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object",menuName = "Inventory System/Items/Default")]
public class DefaultObject : ItemBase
{
    public int damage;
    public void Awake()
    {
        Type = ItemType.Default;
    }
}
