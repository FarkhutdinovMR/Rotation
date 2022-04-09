using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private float _value;

    public event Action Changed;

    public float Value => _value;

    public float MaxHealth => _maxHealth;

    private void Start()
    {
        _value = _maxHealth;
    }

    public void TakeDamage(float value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        _value -= value;

        if (_value < 0)
            _value = 0;

        Changed?.Invoke();

        if (_value == 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}