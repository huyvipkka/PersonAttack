using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable Objects/Enemy")]
public class EnemyData : ScriptableObject
{
    public float speed;
    public int atk;
    public float RecoveryHpDropRate;
    public float BoostSpeedDropRate;    
}