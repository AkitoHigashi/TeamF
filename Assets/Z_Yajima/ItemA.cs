using UnityEngine;

public class ItemA : ItemBase
{
    [SerializeField] int _a;
    public override void EffectActivation()
    {
        Debug.Log("A");
    }
}
