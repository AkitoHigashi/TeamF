using UnityEngine;

/// <summary>
/// プレイヤーのつかむ操作で呼び出されることを前提としたスクリプト
/// これをアタッチしたオブジェクトをプレイヤーの子オブジェクトにする
/// </summary>
public class Hand : MonoBehaviour
{
    [SerializeField, Tooltip("プレイヤーに対してどの位置に手を置くか")] Vector3 _offset;

    private void Start()
    {
        transform.localPosition = _offset;
    }

    /// <summary>
    /// アイテムをつかむ処理をする関数
    /// </summary>
    /// <param name="item"> つかんだアイテム</param>
    public void CatchItem(GameObject item)
    {
        if (item)
        {
            //親設定
            item.transform.SetParent(this.gameObject.transform);
            //position設定
            item.transform.localPosition = Vector3.zero;

            //rotationまたはscale設定が必要なら書いて

            //子オブジェクトの中で一番上に設定
            item.transform.SetAsFirstSibling();
        }
    }
}
