using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _currentImage;

    public void SetValue(float current, float max) => 
        _currentImage.fillAmount = current / max;
}