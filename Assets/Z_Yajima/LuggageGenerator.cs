using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class LuggageRateData
{
    [Header("LuggageData")]
    public GameObject _luggagePrefab;
    [Tooltip("生成の重み（重みの和に対してどれくらいの重みかで確率が決まる）")]
    public float _luggageRate;
    public float _maxGenerate;
}

public class LuggageGenerator : MonoBehaviour
{
    [SerializeField] List<LuggageRateData> _luggageList;
    [SerializeField] List<Vector3> _generatePointList;
    [SerializeField] float _maxAllGenerate = -1;

    Dictionary<LuggageRateData, int> _generateCount = new Dictionary<LuggageRateData, int>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (_luggageList == null || _luggageList.Count <= 0)
        {
            Debug.LogWarning("LuggageListが空です");
        }
        else
        {
            //生成回数の初期化
            foreach (var value in _luggageList)
            {
                _generateCount[value] = 0;
            }
        }

        if (_generatePointList == null || _generatePointList.Count <= 0)
        {
            Debug.LogWarning("GeneratePointListが空です");
        }

        if (_maxAllGenerate > _generatePointList.Count)
        {
            Debug.LogWarning("生成ポイント数が少なすぎます");
        }
        else
        {
            GenerateObject();
        }
    }

    /// <summary>
    /// _maxAllGenerateの回数までオブジェクトを生成する関数
    /// </summary>
    void GenerateObject()
    {
        int rand;
        for (int i = 0; i < _maxAllGenerate; i++)
        {
            var go = GetObject();
            if (go)
            {
                rand = Random.Range(0, _generatePointList.Count);
                Instantiate(go, _generatePointList[rand], Quaternion.identity);
                //生成場所の重複を防ぐ
                _generatePointList.RemoveAt(rand);
            }
        }
    }

    /// <summary>
    /// 生成するゲームオブジェクトを取得する関数
    /// </summary>
    /// <returns> GameObject型が返ってくる</returns>
    GameObject GetObject()
    {
        //重みの総和の計算
        float maxValue = 0;
        foreach (var value in _luggageList)
        {
            //生成上限に達しているオブジェクトについては省く
            if (_generateCount[value] < value._maxGenerate)
            {
                maxValue += value._luggageRate;
            }
        }

        //重み付き確率による評価
        float rand = Random.Range(0, maxValue);
        float nowValue = 0;
        foreach (var value in _luggageList)
        {
            //生成上限に達しているオブジェクトについては省く
            if (_generateCount[value] < value._maxGenerate)
            {
                //重みの加算
                nowValue += value._luggageRate;
                //現在の重みが乱数値以上になったらゲームオブジェクトを返す
                if (nowValue >= rand)
                {
                    _generateCount[value]++;
                    return value._luggagePrefab;
                }
            }
        }

        //生成上限が各オブジェクトの生成上限の和より大きかったらいずれnullを返すようになる
        return null;
    }
}
