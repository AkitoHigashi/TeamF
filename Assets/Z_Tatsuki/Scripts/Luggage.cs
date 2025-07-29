
using UnityEngine;


public class Luggage : MonoBehaviour
{
    [SerializeField] int _luggagescore;　//荷物のスコア
    private int _luggagehp;              //荷物HP
    private bool _isDelivered = false; //配達できたかどうか

    //配達場所においたかどうか
    private void OnTriggerEnter(Collider other)
    {
        if(_isDelivered)return;

        if (other.CompareTag("DeliveryLocation"))
        {
            _isDelivered = true;

            //スコアマネージャーにスコアを加算
            var scoreManager = Object.FindAnyObjectByType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(_luggagescore);
            }
            
            //荷物を削除
            Destroy(gameObject);
        }
    }


}
