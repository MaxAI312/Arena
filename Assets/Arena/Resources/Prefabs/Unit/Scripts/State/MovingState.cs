using UnityEngine;

public class MovingState : IUnitState
{
    private readonly Unit _unit;

    public MovingState(Unit unit)
    {
        _unit = unit;
    }

    public void Enter() => 
        _unit.SetTarget();

    public void Exit()
    {
    }

    public void FixedUpdate()
    {
        if (Vector3.Distance(_unit.transform.position, _unit.Target.transform.position) < _unit.AttackDistance)
            _unit.SetFighting();

        if (_unit.Target == null)
            _unit.SetWaiting();

        _unit.Mover.MoveToTarget(_unit.Target);
    }
}