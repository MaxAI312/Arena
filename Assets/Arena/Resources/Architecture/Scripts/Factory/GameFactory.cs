using UnityEngine;
public class GameFactory : IGameFactory
{
    private readonly IAssets _assets;
    private readonly IStaticDataService _staticData;

    public GameFactory(IAssets assets, IStaticDataService staticData)
    {
        _assets = assets;
        _staticData = staticData;
    }

    public GameObject CreateUI() =>
        _assets.Instantiate(AssetPath.UIPath);

    public GameObject CreateUnit(UnitTypeId unitTypeId, Transform parent)
    {
        UnitStaticData unitData = _staticData.ForMonster(unitTypeId);
        GameObject unit = GameObject.Instantiate(unitData.Prefab, parent.position, Quaternion.identity, parent);
        
        IHealth health = unit.GetComponent<IHealth>();
        health.Current = unitData.Hp;
        health.Max = unitData.Hp;
        
        unit.GetComponent<ActorUI>().Construct(health);
        unit.GetComponent<Attack>().Construct(unitData.Damage);

        return unit;
    }

    public GameObject CreateUnitObserver() => 
        _assets.Instantiate(AssetPath.UnitObserverPath);
}