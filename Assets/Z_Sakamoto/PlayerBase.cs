using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    protected InputBuffer _inputBuffer;
    protected void BaseAwake()
    {
        if (_inputBuffer == null)
        {
            _inputBuffer = FindAnyObjectByType<InputBuffer>();
            if (_inputBuffer == null)
            {
                Debug.LogError("InputBuffer Ç™å©Ç¬Ç©ÇËÇ‹ÇπÇÒÇ≈ÇµÇΩÅI");
            }
        }
    }
}
