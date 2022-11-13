using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StaticDataService : IStaticDataService
{
    private Dictionary<UnitTypeId, UnitStaticData> _monsters;

    public void LoadMonsters()
    {
        _monsters = Resources
            .LoadAll<UnitStaticData>("StaticData/Units")
            .ToDictionary(x => x.UnitTypeId, x => x);
    }

    public UnitStaticData ForMonster(UnitTypeId typeId) => 
        _monsters.TryGetValue(typeId, out UnitStaticData staticData) ? staticData : null;
}