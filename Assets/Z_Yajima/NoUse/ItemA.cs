using UnityEngine;

public class ItemA : ItemBaseData
{
    [SerializeField] int _a;
    public override void EffectActivation()
    {
        Debug.Log("A");
    }
}
