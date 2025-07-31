using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int _score; //スコアの合計

   [SerializeField] private GameClearManager GameClearManager;
    #region スコア処理

    //スコア加算
    public void AddScore(int luggagescore)
    {
        _score += luggagescore;
        Debug.Log("スコア合計" + _score);
         GameClearManager.ClearCheck(_score);
        
    }

    //現在のスコアを取得
    public int GetScore()
    {
        return _score;
    }
    #endregion
}
