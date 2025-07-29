using UnityEngine;

[CreateAssetMenu(fileName ="NewLuggageDatabase",menuName="Luggage Database")]
public class LuggageData : ScriptableObject
{
    public string DisplayName; //荷物の名前
    public int LuggageScore;　//荷物のスコア
    
}
