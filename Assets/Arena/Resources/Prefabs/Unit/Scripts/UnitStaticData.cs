using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "StaticData/Unit")]
public class UnitStaticData : ScriptableObject
{
    public UnitTypeId UnitTypeId;
    
    [Range(1, 100)]
    public int Hp;
    
    [Range(1f, 40f)]
    public float Damage;

    public GameObject Prefab;
}