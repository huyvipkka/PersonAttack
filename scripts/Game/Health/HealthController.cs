using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField] HealthData data;
    [SerializeField] protected float _currentHealth { get; set; }
    [SerializeField] protected float _maximumHealth { get; set; }
    private void Start()
    {
        _maximumHealth = data.HpMax;
        _currentHealth = _maximumHealth;
    }
    public float RemainingHealthPercentage
    {
        get
        {
            return _currentHealth / _maximumHealth;
        }
    }

    public bool IsInvincible { get; set; }

    public UnityEvent OnDied;

    public UnityEvent OnDamaged;

    public UnityEvent OnHealthChanged;

    public void TakeDamage(float damageAmount)
    {
        if (_currentHealth == 0)
        {
            return;
        }

        if (IsInvincible)
        {
            return;
        }

        _currentHealth -= damageAmount;

        OnHealthChanged.Invoke();

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        if (_currentHealth == 0)
        {
            OnDied.Invoke();
        }
        else
        {
            OnDamaged.Invoke();
        }
    }

    public void AddHealth(float amountToAdd)
    {
        if (_currentHealth == _maximumHealth)
        {
            return;
        }

        _currentHealth += amountToAdd;

        OnHealthChanged.Invoke();

        if (_currentHealth > _maximumHealth)
        {
            _currentHealth = _maximumHealth;
        }
    }

    public void ResetHealth()
    {
        _currentHealth = _maximumHealth;
    }
}