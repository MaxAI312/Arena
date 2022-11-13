using UnityEngine;

public class GameLoopState : IState
{
    private readonly IGameFactory _gameFactory;
    private UnitObserver _unitObserver;
    private UI _uI;
    
    public GameLoopState(IGameFactory gameFactory)
    {
        _gameFactory = gameFactory;
    }

    public void Enter()
    {
        _unitObserver = GameObject.FindObjectOfType<UnitObserver>();

        _uI = _gameFactory.CreateUI().GetComponent<UI>();
        _uI.StartMenu.Show();
        _uI.StartMenu.StartButton.onClick.AddListener(StartBattle);
    }

    public void Exit()
    {
        _uI.StartMenu.StartButton.onClick.RemoveListener(StartBattle);
    }

    private void StartBattle()
    {
        _uI.StartMenu.Hide();
        
        for (int i = 0; i < _unitObserver.SpawnedUnits.Count; i++)
        {
            _unitObserver.SpawnedUnits[i].SetMoving();
        }
    }
}