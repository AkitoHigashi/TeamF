using UnityEngine;

public class ItemC : ItemBase
{
    [SerializeField] int _c;
    public override void EffectActivation()
    {
        Debug.Log("C");
    }
}
