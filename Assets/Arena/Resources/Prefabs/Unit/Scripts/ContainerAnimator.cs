using UnityEngine;

public class ContainerAnimator : MonoBehaviour
{
    private const string Idle = "Idle";
    private const string Attack = "Attack";

    [SerializeField] private Animator _animator;

    public void ShowAttack()
    {
        _animator.SetTrigger(Attack);
    }

    public void ShowIdle()
    {
        _animator.SetTrigger(Idle);
    }
}
