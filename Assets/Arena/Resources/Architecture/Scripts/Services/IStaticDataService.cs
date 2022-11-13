public interface IStaticDataService : IService
{
    void LoadMonsters();
    UnitStaticData ForMonster(UnitTypeId typeId);
}