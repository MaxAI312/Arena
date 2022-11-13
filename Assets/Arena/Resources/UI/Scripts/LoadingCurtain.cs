using System.Collections;
using UnityEngine;

public class LoadingCurtain : Menu
{
    private const float MinAlpha = 0f;
    private const float MaxAlpha = 1f;
    private const float StepFading = 0.02f;
    private const float DelayAfterFading = 0.08f;
    
    public override void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public override void Show()
    {
        gameObject.SetActive(true);
        CanvasGroup.alpha = MaxAlpha;
    }

    public override void Hide() => 
        StartCoroutine(FadeIn());

    private IEnumerator FadeIn()
    {
        while (CanvasGroup.alpha > MinAlpha)
        {
            CanvasGroup.alpha -= StepFading;
            yield return new WaitForSeconds(DelayAfterFading);
        }
        
        gameObject.SetActive(false);
    }
}