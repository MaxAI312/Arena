using UnityEngine;

public abstract class Menu : MonoBehaviour
{
    [SerializeField] protected CanvasGroup CanvasGroup;
    
    public virtual void Awake()//Refacroting
    {
        Hide();
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}
