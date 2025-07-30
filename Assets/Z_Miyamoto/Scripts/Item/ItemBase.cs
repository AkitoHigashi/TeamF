using UnityEngine;
public enum ItemType
{
    Default,
    Box
}
public abstract class ItemBase : ScriptableObject
{
    public GameObject Prefab;
    public ItemType Type;
    [TextArea(5,10)]
    public string Description;
}