using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    private IGameFactory _factory;
    
    public UnitTypeId UnitTypeId;

    private void Awake() => 
        _factory = AllServices.Container.Single<IGameFactory>();

    public GameObject GetSpawned() => 
        _factory.CreateUnit(UnitTypeId, transform);
}