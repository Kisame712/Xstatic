using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    private Rigidbody enemyRb;
    private PlayerMovement player;
    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        player = FindFirstObjectByType<PlayerMovement>();
    }

    private void Update()
    {
        float attackRange = 5f;
        if(Vector3.Distance(transform.position, player.transform.position) < attackRange)
        {
            navMeshAgent.SetDestination(player.transform.position);
        }
    }


}
