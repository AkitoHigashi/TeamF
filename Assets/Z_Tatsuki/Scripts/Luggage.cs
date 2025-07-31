
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

    #region 配達処理

    //配達場所への接触処理

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Wall"))
        {
            HitWall();
            return;
        }

        if (collision.gameObject.CompareTag("DeliveryLocation"))
        {
            if (_isDelivered) return;
            CompleteDelivery();
        }
    }




    //配達のスコア処理
    private void CompleteDelivery()
    {

        _isDelivered = true;
       

        if (scoreManager != null)
        {
            scoreManager.AddScore(_luggagescore);
        }

        Destroy(gameObject);
    }
    #endregion

    //壁に接触したときの処理
    private void HitWall()
    {
        _luggagescore = Mathf.Max(_luggagescore - WallDamege, 0);  //比較して大きい方を採用
        Debug.Log($"スコアが{WallDamege}減った現在のスコア{_luggagescore}");

    }


}
