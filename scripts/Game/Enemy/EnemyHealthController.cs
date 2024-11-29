using UnityEngine;

public class EnemyHealthController : HealthController
{
    [SerializeField] public EnemyData data;
    private void Start()
    {
        base._maximumHealth = data.hpMax;
        base._currentHealth = base._maximumHealth;
    }
}