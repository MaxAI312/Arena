using System.Collections.Generic;
using UnityEngine;

public class UnitObserver : MonoBehaviour
{
    [SerializeField] private List<Unit> _spawnedUnits;

    public List<Unit> SpawnedUnits => _spawnedUnits;

    public void AddUnit(Unit unit)
    {
        _spawnedUnits.Add(unit);
    }
    
}
