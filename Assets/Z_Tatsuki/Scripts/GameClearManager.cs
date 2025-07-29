using UnityEngine;

public class GameClearManager : MonoBehaviour
{
    //ステージ選択をしたらゲームのクリアに必要なスコアが更新されるようにしたい
    [SerializeField] int _clearscore = 100;
    private bool _isCleared = false;

    
    public void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E)&&_isCleared)
        {
            Debug.Log("ゲームクリア");
        }
    }
    public void ClearCheck(int currentscore)
    {
        if (!_isCleared && currentscore >= _clearscore)
        {
            _isCleared = true;

        }
    }
}
