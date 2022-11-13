using UnityEngine;

public interface IGameFactory : IService
{
    GameObject CreateUI();
    GameObject CreateUnit(UnitTypeId unitTypeId, Transform parent);
    GameObject CreateUnitObserver();
}