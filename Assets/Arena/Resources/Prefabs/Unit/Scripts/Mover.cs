using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;

    public void MoveToTarget(Unit target) => 
        _navMeshAgent.SetDestination(target.transform.position);

    public void StopMove() => 
        _navMeshAgent.isStopped = false;
}
