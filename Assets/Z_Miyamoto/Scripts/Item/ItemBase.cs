using UnityEngine;
public enum ItemType
{
    Default,
    Box
}
public abstract class ItemBase : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [TextArea(5,10)]
    public string description;
}
