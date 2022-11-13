using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float _damage;

    public float Damage => _damage;

    public void Construct(float damage)
    {
        _damage = damage;
    }
}
