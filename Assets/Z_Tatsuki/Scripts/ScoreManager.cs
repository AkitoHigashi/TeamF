using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int Score; //スコアの合計


    #region スコア処理
    public void AddScore(int luggagescore)
    {
        Score += luggagescore;
        Debug.Log("スコア加算" + Score);
    }

    //現在のスコアを取得
    public int GetScore()
    {
        return Score;
    }
    #endregion
}
