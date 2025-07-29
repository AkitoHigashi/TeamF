using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Luggage : MonoBehaviour
{
    [SerializeField] int  _luggagescore;　//荷物のスコア
    private int _luggagehp;              //荷物HP
    private bool _isDelivered = false; //配達できたかどうか

}
