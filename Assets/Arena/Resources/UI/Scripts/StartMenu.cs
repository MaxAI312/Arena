using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : Menu
{
    private const float MinAlpha = 0f;
    private const float MaxAlpha = 1f;
    
    [SerializeField] private Button _startButton;

    private WaitForSeconds _delayBeforeShowing = new WaitForSeconds(1.25f);
    
    public Button StartButton => _startButton;

    public override void Show()
    {
        base.Show();
        CanvasGroup.alpha = MinAlpha;
        StartCoroutine(DelayShowing());

    }

    private IEnumerator DelayShowing()
    {
        yield return _delayBeforeShowing;
        CanvasGroup.alpha = MaxAlpha;
    }
}
