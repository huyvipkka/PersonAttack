using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField] private PlayerData data;
    [SerializeField] protected float _currentHealth { get; set; }
    [SerializeField] protected float _maximumHealth { get; set; }
    private void Start()
    {
        _maximumHealth = data.hpMax;
        _currentHealth = _maximumHealth;
    }
    public float GetPercentHp() => _currentHealth/_maximumHealth; 
    public bool IsInvincible { get; set; }

    public UnityEvent OnDied;

    public UnityEvent OnDamaged;

    public UnityEvent OnHealthChanged;

    public void TakeDamage(float damageAmount)
    {
        if (_currentHealth == 0) return;
        if (IsInvincible) return;

        _currentHealth = Mathf.Max(_currentHealth - damageAmount, 0);
        if (_currentHealth == 0) OnDied.Invoke();
        else OnDamaged.Invoke();
    }

    public void AddHealth(float amountToAdd)
    {
        if (_currentHealth == _maximumHealth) return;
        _currentHealth = Mathf.Min(_currentHealth + amountToAdd, _maximumHealth);
    }

    public void ResetHealth()
    {
        _currentHealth = _maximumHealth;
    }
}