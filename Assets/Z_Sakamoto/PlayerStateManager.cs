using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public PlayerState CurrentState=PlayerState.walking;
    public enum PlayerState
    {
        walking,
        sprinting,
        carrying,
        throwing,
    }
}
