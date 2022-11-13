using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private StartMenu _startMenu;
    [SerializeField] private EndLevelMenu _endLevelMenu;

    public StartMenu StartMenu => _startMenu;
    public EndLevelMenu EndLevelMenu => _endLevelMenu;
}
