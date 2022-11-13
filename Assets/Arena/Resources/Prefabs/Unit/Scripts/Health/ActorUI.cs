using UnityEngine;

public class ActorUI : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;

    private IHealth _unitHealth;

    public void Construct(IHealth health)
    {
        _unitHealth = health;
        _unitHealth.HealthChanged += UpdateHealthBar;
    }

    private void OnDisable() => 
        _unitHealth.HealthChanged -= UpdateHealthBar;

    private void UpdateHealthBar() => 
        _healthBar.SetValue(_unitHealth.Current, _unitHealth.Max);
}