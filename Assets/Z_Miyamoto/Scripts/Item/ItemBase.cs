using UnityEngine;
public enum ItemType
{
    Default,
    Box
}
public abstract class ItemBase : ScriptableObject
{
    public ItemType Type;
    public GameObject Prefab;
    public string Name;
    public Sprite Icon;
    [TextArea(5,10)]
    public string Description;
}