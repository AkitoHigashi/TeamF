using System.Collections;
using UnityEngine;

public class NeedleTrapMovement : MonoBehaviour
{
    [SerializeField, Tooltip("トラップの待ち時間")]
    private float WaitTime = 1f;

    [SerializeField, Tooltip("トラップの上がり幅")]
    private float NeedlY = 1f;

    [SerializeField,Tooltip("移動にかかる時間")]
    private float MoveDuration = 0.5f;

    private Vector3 _startPos;
    private Vector3 _endPos;

    void Start()
    {
        //初めの位置を保存
        _startPos = transform.position;
        _endPos = _startPos + new Vector3(0, NeedlY, 0);

        StartCoroutine(MoveTrapLoop());
    }

    IEnumerator MoveTrapLoop()
    {


        while (gameObject)
        {
            // 上がる
            yield return StartCoroutine(SmoothMove(_startPos, _endPos, MoveDuration));
            yield return new WaitForSeconds(WaitTime);

            // 下がる
            yield return StartCoroutine(SmoothMove(_endPos, _startPos, MoveDuration));
            yield return new WaitForSeconds(WaitTime);
        }
    }

    IEnumerator SmoothMove(Vector3 from, Vector3 to, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            transform.position = Vector3.Lerp(from, to, t);
            yield return null; // 次のフレームまで待つ
        }

        transform.position = to; // 最後に位置をしっかり合わせる
    }
}
