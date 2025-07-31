using UnityEngine;

[CreateAssetMenu(fileName = "NewLuggageDatabase", menuName = "Luggage Database")]
public class LuggageData : ScriptableObject
{
    /// <summary>
    /// 表示用の名前（読み取り専用プロパティ）
    /// </summary>
    public string DisplayName => _displayName;

    /// <summary>
    /// 配達時に加算されるスコア（読み取り専用プロパティ）
    /// </summary>
    public int LuggageScore => _luggageScore;

    [SerializeField, Tooltip("インスペクター上で表示する荷物の名前")]
    private string _displayName;
    [SerializeField, Tooltip("この荷物を配達したときに加算されるスコア")]
    private int _luggageScore;
}
