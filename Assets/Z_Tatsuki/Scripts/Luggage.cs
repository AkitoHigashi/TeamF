
using UnityEngine;


public class Luggage : MonoBehaviour
{
    public LuggageData LuggageDatabase;
    [SerializeField] int _luggagescore;　//荷物のスコア
    private bool _isDelivered = false; //配達できたかどうか

    private void Start()
    {
        _luggagescore = LuggageDatabase.LuggageScore;
    }

    #region 配達処理
    //配達場所への接触処理
    private void OnTriggerEnter(Collider other)
    {
        if (_isDelivered) return;

        if (other.CompareTag("DeliveryLocation"))
        {
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



}
