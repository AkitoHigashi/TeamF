using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// 手の子オブジェクトにしてインベントリを表現するためのクラス
/// </summary>
public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField, Tooltip("手の役割をしているオブジェクト")] GameObject _hand;

    [Header("SlotUI")]
    [SerializeField] GameObject _slot1;
    [SerializeField] GameObject _slot2;
    [SerializeField] GameObject _slot3;

    //各キーに対応したインベントリのキュー
    static Queue<GameObject> _oneQueue = new Queue<GameObject>();
    static Queue<GameObject> _twoQueue = new Queue<GameObject>();
    static Queue<GameObject> _threeQueue = new Queue<GameObject>();

    /// <summary>
    /// 現在持っているアイテム
    /// </summary>
    GameObject _nowHoldItem = null;

    //**********************
    //PlayerData _playerData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //最初にプレイヤーが持っているものがアイテムだったら
        if (_hand.transform.GetChild(0).GetComponent<ItemBase>())
        {
            _nowHoldItem = _hand.transform.GetChild(0).gameObject;
        }

        //各キューには空のデータをあらかじめ保存しておく
        //（インベントリのアイテム入れ替えを実装するため）
        if (_oneQueue.Count == 0 || _oneQueue == null)
        {
            _oneQueue.Enqueue(null);
        }
        if (_twoQueue.Count == 0 || _twoQueue == null)
        {
            _twoQueue.Enqueue(null);
        }
        if (_threeQueue.Count == 0 || _threeQueue == null)
        {
            _threeQueue.Enqueue(null);
        }

        //現在のインベントリに対応するUIで初期化
        SetSlotUI(_oneQueue, _slot1);
        SetSlotUI(_twoQueue, _slot2);
        SetSlotUI(_threeQueue, _slot3);

        //*************************************************
        //_playerData = _player.GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        //現在つかんでいるオブジェクトがアイテムかどうかを判定
        if (!_hand.transform.GetChild(0).GetComponent<ItemBase>())
        {
            _nowHoldItem = null;
        }
        else
        {
            _nowHoldItem = _hand.transform.GetChild(0).gameObject;
        }

        //キーに対応したインベントリの操作
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("1キー");
            ItemSetForInventory(_oneQueue,_slot1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("2キー");
            ItemSetForInventory(_twoQueue,_slot2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("3キー");
            ItemSetForInventory(_threeQueue,_slot3);
        }

        //アイテム使用
        if (Input.GetMouseButtonDown(1))
        {
            ItemUse();
        }
    }

    /// <summary>
    /// 各キーのインベントリの操作をする関数
    /// </summary>
    /// <param name="queue"> 押したキーに対応するインベントリ</param>
    /// <param name="slot"> 押したキーに対応するインベントリのUI</param>
    void ItemSetForInventory(Queue<GameObject> queue,GameObject slot)
    {
        //現在何かアイテムを持っている場合、非アクティブにしてこのオブジェクトの子にする
        _nowHoldItem?.SetActive(false);
        _nowHoldItem?.transform.SetParent(this.transform);

        //現在持っているオブジェクトがアイテム、または空のデータの時
        if (_nowHoldItem?.GetComponent<ItemBase>() || _nowHoldItem == null)
        {
            //キューに追加
            queue.Enqueue(_nowHoldItem);

            //プレイヤーのStateをwalkingにする処理
            if (_nowHoldItem?.GetComponent<ItemBase>())
            {
                Debug.Log("Player:Walking");
            }
            //**********************************************
            //_playerData = PlayerData.PlayerState.walking;
        }

        //キューに2個以上データが入ったとき（常に処理される想定）
        if (queue.Count > 1)
        {
            //キューからオブジェクトを取り出す
            _nowHoldItem = queue.Dequeue();

            //プレイヤーのStateをcarryingにする処理
            if (_nowHoldItem?.GetComponent<ItemBase>())
            {
                Debug.Log("Player:carrying");
            }
            //*********************************************
            //_playerData= PlayerData.PlayerState.carrying;
        }

        //インベントリからアイテムを取り出したとき、手のオブジェクトの子にしてアクティブにする
        _nowHoldItem?.transform.SetParent(_hand.transform);
        _nowHoldItem?.transform?.SetAsFirstSibling();
        _nowHoldItem?.SetActive(true);

        //UI更新
        SetSlotUI(queue, slot);
    }

    /// <summary>
    /// アイテムを使用するときの処理をする関数
    /// </summary>
    void ItemUse()
    {
        var item = _nowHoldItem.GetComponent<ItemBase>();
        if (item)
        {
            item.EffectActivation();
            Destroy(item.gameObject);
        }
    }

    /// <summary>
    /// インベントリのUIを更新する関数
    /// </summary>
    /// <param name="queue"> 押したキーに対応するインベントリ</param>
    /// <param name="ui"> 押したキーに対応するインベントリのUI</param>
    void SetSlotUI(Queue<GameObject> queue, GameObject ui)
    {
        //スロットに入っているオブジェクトを取得
        var go = queue.Peek();
        if (go != null)
        {
            ui.GetComponent<Image>().sprite = go.GetComponent<ItemBase>().Sprite;
        }
        else
        {
            ui.GetComponent<Image>().sprite = null;
        }
    }
}
