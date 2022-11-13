using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateMachine : MonoBehaviour
{
    [SerializeField] private Unit _unit;

    private Dictionary<Type, IUnitState> _statesMap;
    private IUnitState _currentState;

    private void Awake()
    {
        InitStates();
    }

    private void OnEnable()
    {
        _unit.Waited += SetWaitingState;
        _unit.Moved += SetMovingState;
        _unit.Attacked += SetAttackingState;
        _unit.Died += SetDyingState;
    }

    private void OnDisable()
    {
        _unit.Waited -= SetWaitingState;
        _unit.Moved -= SetMovingState;
        _unit.Attacked -= SetAttackingState;
        _unit.Died -= SetDyingState;
    }

    private void Start()
    {
        SetStateByDefault();
    }

    private void InitStates()
    {
        _statesMap = new Dictionary<Type, IUnitState>()
        {
            [typeof(WaitingState)] = new WaitingState(),
            [typeof(MovingState)] = new MovingState(_unit),
            [typeof(AttackingState)] = new AttackingState(_unit),
            [typeof(DyingState)] = new DyingState(_unit)
        };
    }

    private void SetStateByDefault()
    {
        SetWaitingState();
    }

    private void SetWaitingState()
    {
        var state = GetState<WaitingState>();
        SetState(state);
    }

    private void SetMovingState()
    {
        var state = GetState<MovingState>();
        SetState(state);
    }

    private void SetAttackingState()
    {
        var state = GetState<AttackingState>();
        SetState(state);
    }

    private void SetDyingState()
    {
        var state = GetState<DyingState>();
        SetState(state);
    }

    private void SetState(IUnitState newState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = newState;
        newState.Enter();
    }

    private IUnitState GetState<TState>() where TState : IUnitState
    {
        var type = typeof(TState);
        return _statesMap[type];
    }

    private void FixedUpdate()
    {
        if (_currentState != null)
            _currentState.FixedUpdate();
    }
}