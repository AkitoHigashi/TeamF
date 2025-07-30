using UnityEngine;

[CreateAssetMenu(fileName = "New Box Object", menuName = "Inventory System/Items/Box")]
public class BoxObject : ItemBase
{
    public float a;
    public void Awake()
    {
        Type = ItemType.Box;
    }
}
