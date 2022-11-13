public class AttackingState : IUnitState
{
    private readonly Unit _unit;
    
    public AttackingState(Unit unit)
    {
        _unit = unit;
    }
    
    public void Enter()
    {
        _unit.Mover.StopMove();
        _unit.ContainerAnimator.ShowAttack();
    }

    public void Exit() => 
        _unit.ContainerAnimator.ShowIdle();


    public void FixedUpdate()
    {
    }
}