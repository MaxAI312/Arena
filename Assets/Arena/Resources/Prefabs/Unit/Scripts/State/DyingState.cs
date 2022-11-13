public class DyingState : IUnitState
{
    private readonly Unit _unit;

    public DyingState(Unit unit)
    {
        _unit = unit;
    }

    public void Enter() => 
        _unit.gameObject.SetActive(false);


    public void Exit()
    {
    }

    public void FixedUpdate()
    {
    }
}