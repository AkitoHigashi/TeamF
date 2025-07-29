using UnityEngine;

[CreateAssetMenu(fileName ="NewLuggageDatabase",menuName="Luggage Database")]
public class LuggageData : ScriptableObject
{
    public string DisplayName => _displayName; //荷物の名前
    public int LuggageScore => _luggageScore; //荷物のスコア

    [SerializeField] private string _displayName;　　//カプセル化
    [SerializeField] private int _luggageScore;

}
