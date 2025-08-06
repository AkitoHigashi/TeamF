using UnityEngine;

public class ItemC : ItemBaseData
{
    [SerializeField] int _c;
    public override void EffectActivation()
    {
        Debug.Log("C");
    }
}
