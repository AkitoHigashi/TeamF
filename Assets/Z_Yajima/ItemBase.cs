using UnityEngine;

/// <summary>
/// アイテムの基本となるスクリプトで、継承することを前提としている
/// </summary>
public abstract class ItemBase : MonoBehaviour
{
    [SerializeField,Tooltip("インベントリに設定するUI")] Sprite _sprite;
    public Sprite Sprite => _sprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //タグの設定
        if (gameObject.tag != "Item")
        {
            gameObject.tag = "Item";
        }

        if (!_sprite)
        {
            Debug.Log("Spriteが設定されていません");
        }
    }

    /// <summary>
    /// アイテムの効果を発動する関数
    /// </summary>
    public abstract void EffectActivation();
}
