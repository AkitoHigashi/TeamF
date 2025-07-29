using System.Collections;
using UnityEngine;

public class Needle : MonoBehaviour
{
    private Transform myTransform;

    [Header("トラップの待ち時間")]
    public float waitTime = 1f;

    [Header("トラップの上がり幅")]
    public float needlY = 1f;

    [Header("移動にかかる時間")]
    public float moveDuration = 0.5f;

    private Vector3 startPos;
    private Vector3 endPos;

    void Start()
    {
        myTransform = transform;
        //初めの位置を保存
        startPos = myTransform.position;
        endPos = startPos + new Vector3(0, needlY, 0);

        StartCoroutine(MoveTrapLoop());
    }

    IEnumerator MoveTrapLoop()
    {
        while (true)
        {
            // 上がる
            yield return StartCoroutine(SmoothMove(startPos, endPos, moveDuration));
            yield return new WaitForSeconds(waitTime);

            // 下がる
            yield return StartCoroutine(SmoothMove(endPos, startPos, moveDuration));
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator SmoothMove(Vector3 from, Vector3 to, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            myTransform.position = Vector3.Lerp(from, to, t);
            yield return null; // 次のフレームまで待つ
        }

        myTransform.position = to; // 最後に位置をしっかり合わせる
    }
}
