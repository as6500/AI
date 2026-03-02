using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class StateMachine : MonoBehaviour
{
    private enum AIState
    {
        Patrol,
        Chase,
        Attack,
    }
    
    [SerializeField] private AIState currentState = AIState.Patrol;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject chaseObject;
    void Update()
    {
        if (currentState == AIState.Patrol)
        {
            Debug.Log("Patrol");
        }
        else if (currentState == AIState.Chase)
        {
            Debug.Log("Chase");
            agent.destination = chaseObject.transform.position;
        }        
        else if (currentState == AIState.Attack)
        {
            Debug.Log("Attack!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        } 
        currentState = AIState.Chase;
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }
        currentState = AIState.Patrol;
    }

    public void Attack(bool state)
    {
        if(state)
            currentState = AIState.Attack;
        else
            currentState = AIState.Chase;
    }
}
