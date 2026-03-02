using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class NPCAttack : MonoBehaviour
{
    public UnityEvent<bool> OnEnterAttackRange;
    public UnityEvent<bool> OnExitAttackRange;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        OnEnterAttackRange?.Invoke(true);
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        OnExitAttackRange?.Invoke(false);
    }
    
}
