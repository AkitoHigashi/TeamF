using UnityEngine;

public class ItemB : ItemBaseData
{
    [SerializeField] int _b;
    public override void EffectActivation()
    {
        Debug.Log("B");
    }
}
