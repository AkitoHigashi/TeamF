
using UnityEngine;


public class Luggage : MonoBehaviour
{
    public LuggageData LuggageData;
    private int _luggagescore;　//荷物のスコア
    private bool _isDelivered = false; //配達できたかどうか
    private bool _hitWall = false; //壁にあたったかどうか

    private void Start()
    {
        if (LuggageData != null) {
            _luggagescore = LuggageData.LuggageScore; //荷物データベースからスコアを参照
            gameObject.name = LuggageData.name;　　　//　ゲームが始まったら名前を変更
        }
    }

    #region 配達処理
    //配達場所への接触処理
   
   
    
        private void OnCollisionEnter(Collision collision)
    {
        var tag = collision.gameObject.tag;

        if (tag == "Wall")
        {
            HitWall();
            return;
        }

        if (tag == "DeliveryLocation")
        {
            if (_isDelivered) return;
            CompleteDelivery();
        }
    }




//配達のスコア処理
private void CompleteDelivery()
    {
        _isDelivered = true;
        var scoreManager = Object.FindAnyObjectByType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.AddScore(_luggagescore);
        }
        Destroy(gameObject);
    }
    #endregion
    private void HitWall()
    {
        _luggagescore -= 5;

    }


}
