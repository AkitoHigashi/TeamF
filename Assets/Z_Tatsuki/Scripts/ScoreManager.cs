using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField, Tooltip("現在のスコアの合計")]
    private int _score;
    [SerializeField, Tooltip("ゲームクリア管理スクリプトの参照")]
    private GameClearManager gameClearManager;

    #region スコア処理

    //スコア加算
    public void AddScore(int luggagescore)
    {
        _score += luggagescore;
        Debug.Log("スコア合計" + _score);
         gameClearManager.ClearCheck(_score);
        
    }

    //現在のスコアを取得
    public int GetScore()
    {
        return _score;
    }
    #endregion
}
