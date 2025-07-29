using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Hit : MonoBehaviour
{
    public float knockbackForce = 10f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("敵と衝突した");
            //ノックバック方向の計算
            Vector3 knockbackDirection = (transform.position - other.transform.position).normalized;

            rb.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
        }
    }
}