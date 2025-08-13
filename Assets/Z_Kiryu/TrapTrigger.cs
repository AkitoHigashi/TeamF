using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TrapTrigger : MonoBehaviour
{
    public float KnockbackForce = 10f;
    private Rigidbody _rb;
    private const string TRAP_TAG_NAME = "NeedleTrap";

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        if (!TryGetComponent(out _rb))
        {
            Debug.LogError($"Rigidbody of {gameObject.name} is null");
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TRAP_TAG_NAME))
        {
            Debug.Log("敵と衝突した");
            //ノックバック方向の計算
            Vector3 knockbackDirection = (transform.position - other.transform.position).normalized;

            _rb.AddForce(knockbackDirection * KnockbackForce, ForceMode.Impulse);
        }
    }
}