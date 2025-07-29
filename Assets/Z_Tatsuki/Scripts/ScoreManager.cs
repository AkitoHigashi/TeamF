using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int Score; //スコアの合計

   public GameClearManager GameClearManager;
    #region スコア処理
    public void AddScore(int luggagescore)
    {
        Score += luggagescore;
        Debug.Log("スコア合計" + Score);
         GameClearManager.ClearCheck(Score);
        
    }

    //現在のスコアを取得
    public int GetScore()
    {
        return Score;
    }
    #endregion
}
