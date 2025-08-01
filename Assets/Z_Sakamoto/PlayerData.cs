using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public PlayerState CurrentState=PlayerState.walking;
    [HideInInspector] public GameObject Luggage;
    [HideInInspector] public Rigidbody LuggageRb;
    public enum PlayerState
    {
        walking,
        sprinting,
        carrying,
        throwing,
        crouching,
    }
}
