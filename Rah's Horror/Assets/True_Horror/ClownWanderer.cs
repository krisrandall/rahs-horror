using UnityEngine;
using UnityEngine.AI;

public class ClownWanderer : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        InvokeRepeating("SetNewDestination", 0f, 3f);
    }
    
    void SetNewDestination()
    {
        Vector3 randomPoint = transform.position + Random.insideUnitSphere * 10f;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 10f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }
    
    void Update()
    {
        animator.SetBool("isWalking", agent.velocity.magnitude > 0.1f);
    }
}