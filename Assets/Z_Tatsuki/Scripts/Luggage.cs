
using UnityEngine;


public class Luggage : MonoBehaviour
{
    [SerializeField] private LuggageData _luggageData;
    private int _luggagescore;　//荷物のスコア
    private bool _isDelivered = false; //配達できたかどうか
    public int WallDamege = 10;
    private ScoreManager scoreManager;

    private void Start()
    {
        if (_luggageData != null)
        {
            _luggagescore = _luggageData.LuggageScore; //荷物データベースからスコアを参照
            gameObject.name = _luggageData.name;   //　ゲームが始まったら名前を変更
            scoreManager = Object.FindAnyObjectByType<ScoreManager>();
        }
        else
        {
            Debug.LogWarning("荷物データが入っていません");
        }
    }

    #region 接触処理

    /// <summary>
    /// 他のオブジェクトと衝突したときに呼ばれる処理。
    /// 壁または配達先への接触を判定する。
    /// </summary>
    /// <param name="collision">衝突したオブジェクトの情報</param>
    private void OnCollisionEnter(Collision collision)
    {
        //壁への接触処理
        if (collision.gameObject.CompareTag("Wall"))
        {
            HitWall();
            return;
        }

        //配達場所への接触処理
        if (collision.gameObject.CompareTag("DeliveryLocation"))
        {
            if (_isDelivered) return;
            CompleteDelivery();
        }
    }

    /// <summary>
    /// 配達完了時の処理。スコアを加算し、自身を削除する。
    /// </summary>
    private void CompleteDelivery()
    {
        _isDelivered = true;

        if (scoreManager != null)
        {
            scoreManager.AddScore(_luggagescore);
        }

        Destroy(gameObject);
    }

    /// <summary>
    /// 壁に接触したときの処理。スコアを減少させる。
    /// </summary>
    private void HitWall()
    {
        _luggagescore = Mathf.Max(_luggagescore - WallDamege, 0);  //比較して大きい方を採用
        Debug.Log($"スコアが{WallDamege}減った 現在のスコア {_luggagescore}");
    }

    #endregion



}
