using UnityEngine;

public class LoadLevelState : IPayloadedState<string>
{
    private const string EnemySpawnerTag = "UnitSpawner";

    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly LoadingCurtain _loadingCurtain;
    private readonly IGameFactory _gameFactory;

    public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain,
        IGameFactory gameFactory)
    {
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
        _loadingCurtain = loadingCurtain;
        _gameFactory = gameFactory;
    }

    public void Enter(string sceneName)
    {
        _loadingCurtain.Show();
        _sceneLoader.Load(sceneName, OnLoaded);
    }

    public void Exit() =>
        _loadingCurtain.Hide();

    private void OnLoaded()
    {
        InitSpawners();
        
        _stateMachine.Enter<GameLoopState>();
    }

    private void InitSpawners()
    {
        UnitObserver unitObserver = _gameFactory.CreateUnitObserver().GetComponent<UnitObserver>();

        foreach (var spawnerObject in GameObject.FindGameObjectsWithTag(EnemySpawnerTag))
        {
            UnitSpawner spawner = spawnerObject.GetComponent<UnitSpawner>();
            GameObject spawned = spawner.GetSpawned();

            if (spawned.TryGetComponent(out Unit unit))
                unitObserver.AddUnit(unit);
        }

        foreach (var unit in unitObserver.SpawnedUnits)
            unit.InitializeTargets(unitObserver.SpawnedUnits);
    }
}