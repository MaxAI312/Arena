using System;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Unit : MonoBehaviour
{
    [SerializeField] private UnitHealth _health;
    [SerializeField] private Mover _mover;
    [SerializeField] private float _attackDistance;
    [SerializeField] private ContainerAnimator _containerAnimator;
    [SerializeField] private Attack _attack;

    private Unit _target;
    private List<Unit> _targets;

    public UnitHealth Health => _health;
    public Mover Mover => _mover;
    public Unit Target => _target;
    public float AttackDistance => _attackDistance;
    public ContainerAnimator ContainerAnimator => _containerAnimator;
    public bool IsAlive { get; private set; } = true;

    public event Action Waited;
    public event Action Moved;
    public event Action Attacked;
    public event Action Died;

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
        IsAlive = true;
    }

    private void OnHealthChanged()
    {
        if (_health.Current <= 0)
        {
            Died?.Invoke();
            IsAlive = false;
        }
    }

    public void InitializeTargets(List<Unit> targets)
    {
        if (targets != null)
            _targets = targets;
    }

    public void SetTarget()
    {
        _target = GetTarget();
        if (_target == null)
        {
            Waited?.Invoke();
            return;
        }

        if (_target.IsAlive)
            _target.Died += OnTargetDied;
    }

    //Used in Animation Attack
    public void HitTarget()
    {
        if (_target != null)
        {
            if (_target.Health.Current <= 0)
                Moved?.Invoke();
            else
                _target.GetComponent<IHealth>().TakeDamage(_attack.Damage);
        }
    }

    public void SetWaiting() => 
        Waited?.Invoke();

    public void SetMoving() => 
        Moved?.Invoke();

    public void SetFighting() => 
        Attacked?.Invoke();

    private Unit GetTarget()
    {
        Unit nearestTarget = null;
        float distanceToNearestTarget = float.MaxValue;

        for (int i = 0; i < _targets.Count; i++)
        {
            if (_targets[i] != this && _targets[i].IsAlive)
            {
                float distanceToTarget = Vector3.Distance(transform.position, _targets[i].transform.position);
                if (distanceToTarget < distanceToNearestTarget)
                {
                    nearestTarget = _targets[i];
                    distanceToNearestTarget = distanceToTarget;
                }
            }
        }

        return nearestTarget;
    }

    private void OnTargetDied()
    {
        Moved?.Invoke();
        _target.Died -= OnTargetDied;
    }
}