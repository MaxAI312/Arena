using System;
using UnityEngine;

public class UnitHealth : MonoBehaviour, IHealth
{
    [SerializeField] private float _current;
    [SerializeField] private float _max;

    public event Action HealthChanged;

    public float Current
    {
        get => _current;
        set
        {
            if (_current != value)
            {
                _current = value;
                HealthChanged?.Invoke();
            }
        }
    }

    public float Max
    {
        get => _max;
        set => _max = value;
    }


    public void TakeDamage(float damage)
    {
        _current -= damage;
        
        HealthChanged?.Invoke();
    }
}