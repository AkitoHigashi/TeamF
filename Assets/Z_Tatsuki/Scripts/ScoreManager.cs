using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int Score; //スコアの合計
    [SerializeField] int ClearScore; //クリアするための最低限スコア
   
    #region スコア処理
    public void AddScore(int luggagescore)
    {
        Score += luggagescore;
        Debug.Log("スコア加算" + Score);
        if (Score > ClearScore)
        {

        }
    }

    //現在のスコアを取得
    public int GetScore()
    {
        return Score;
    }
    #endregion
}
