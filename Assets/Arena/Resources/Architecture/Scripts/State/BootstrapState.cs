public class BootstrapState : IState
{
    private const string Initial = "00_Initial";
    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly AllServices _services;

    public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
    {
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
        _services = services;
        
        RegisterServices();
    }

    public void Enter()
    {
        _sceneLoader.Load(Initial , onLoaded: EnterLoadLevel);
    }

    private void EnterLoadLevel()
    {
        _stateMachine.Enter<LoadLevelState, string>("01_Level");
    }

    private void RegisterServices()
    {
        RegisterStaticData();
        _services.RegisterSingle<IAssets>(new AssetProvider());
        _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssets>(), _services.Single<IStaticDataService>()));
    }

    private void RegisterStaticData()
    {
        IStaticDataService staticData = new StaticDataService();
        staticData.LoadMonsters();
        _services.RegisterSingle<IStaticDataService>(staticData);
    }

    public void Exit()
    {
    }
}