using UnityEngine;

public class Player : MonoBehaviour

{
    public float moveSpeed = 5f; // 移動速度

    void Update()
    {
        // 入力を取得（横方向: A,D,←,→）（縦方向: W,S,↑,↓）
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // 移動する方向ベクトル
        Vector3 direction = new Vector3(horizontal, 0, vertical);

        // 方向に応じて移動（速度 × 時間）
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

}