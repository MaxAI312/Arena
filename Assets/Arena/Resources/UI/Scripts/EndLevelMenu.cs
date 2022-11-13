using UnityEngine;
using UnityEngine.UI;

public class EndLevelMenu : Menu
{
    [SerializeField] private Button _restartButton;

    public Button RestartButton => _restartButton;
}
