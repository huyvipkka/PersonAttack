using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable Objects/Enemy")]
public class EnemyData : ScriptableObject
{
    public int hp;
    public float speed;
    public float speedBoost;
    public int atk;
    public float cooldownAttack;
    public float RecoveryHpDropRate;
    public float BoostSpeedDropRate;
    public float xuDropRate;
    public int xuValue;

}